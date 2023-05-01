using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using EZInput;
using Task02.BL;

namespace Task02
{
    class Program
    {
        static int score = 0; // score
        static void Main(string[] args)
        {
            List<Bullet> B = new List<Bullet>();

            char[,] Maze = new char[26, 70]; // All Arrays
            char[,] Buddy = new char[3, 4];
            char[,] BuddyLeft = new char[3, 4];
            char[,] Enemy = new char[3, 5];
            LoadMaze(Maze);
            LoadBuddy(Buddy);
            LoadBuddyLeft(BuddyLeft);
            LoadEnemy(Enemy);

            int B_X = 3;
            int B_Y = 22;
            int B_health = 100;
            string B_printDirection = "right";
            bool isJump = false;
            int jumpTick = 0;

            FBuddy CBuddy = new FBuddy(B_X, B_Y, B_health, B_printDirection, isJump, jumpTick);

            /*int[] bulletX = new int[100];
            int[] bulletY = new int[100];
            char[] bulletDirection = new char[100];
            int bulletCount = 0;*/

            int E1_X = 62; // enemy1 coordinates and health
            int E1_Y = 22;
            string E1_direction = "down";
            int E1_health = 50;

            Enemy1 CEnemy1 = new Enemy1(E1_X, E1_Y, E1_direction, E1_health);

            bool game = true;

            Console.Clear();
            PrintMaze(Maze);
            PrintEnemy1(Enemy, CEnemy1);
            printBuddy(Buddy, CBuddy);

            while (game)
            {
                printScore();
                printBuddyHealth(CBuddy);
                moveEnemy(Maze, Enemy, CEnemy1);
                gameover(CBuddy, ref game);
                gameoverCollsion(CBuddy, CEnemy1);
                Printenemyhealth(ref game, CEnemy1);
                controlBuddy(Maze, Buddy, BuddyLeft, CBuddy, B, ref game, CEnemy1);
                movebullet(Maze, B);
                collision(CEnemy1, B, ref score);
                Thread.Sleep(50);
            }

            Console.ReadKey();
        }

        static void PrintMaze(char[,] Maze)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 70; j++)
                {
                    Console.Write(Maze[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void moveBuddyDown(char[,] Maze, char[,] Buddy, char[,] BuddyLeft, FBuddy CBuddy)
        {
            char next = Maze[CBuddy.Y + 3, CBuddy.X];
            char next1 = Maze[CBuddy.Y + 3, CBuddy.X + 1];
            char next2 = Maze[CBuddy.Y + 3, CBuddy.X + 2];
            char next3 = Maze[CBuddy.Y + 3, CBuddy.X + 3];
            if (next == ' ' && next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseBuddy(CBuddy);
                CBuddy.Y++;
                if (CBuddy.printDirection == "right")
                {
                    printBuddy(Buddy, CBuddy);
                }
                else
                {
                    printBuddyLeft(BuddyLeft, CBuddy);
                }
            }

            else if (next == '$' || next1 == '$' || next2 == '$' || next3 == '$')
            {
                score = score + 10;
                eraseBuddy(CBuddy);
                CBuddy.Y++;
                if (CBuddy.printDirection == "right")
                {
                    printBuddy(Buddy, CBuddy);
                }
                else
                {
                    printBuddyLeft(BuddyLeft, CBuddy);
                }
            }
        }

        static void moveBuddyUp(char[,] Maze, char[,] Buddy, char[,] BuddyLeft, FBuddy CBuddy)
        {
            char next = Maze[CBuddy.Y - 1, CBuddy.X];
            char next1 = Maze[CBuddy.Y - 1, CBuddy.X + 1];
            char next2 = Maze[CBuddy.Y - 1, CBuddy.X + 2];
            char next3 = Maze[CBuddy.Y - 1, CBuddy.X + 3];
            if (next == ' ' && next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseBuddy(CBuddy);
                CBuddy.Y--;
                if (CBuddy.printDirection == "right")
                {
                    printBuddy(Buddy, CBuddy);
                }
                else
                {
                    printBuddyLeft(BuddyLeft, CBuddy);
                }
            }

            if (next == '$' || next1 == '$' || next2 == '$' || next3 == '$')
            {
                score = score + 10;
                eraseBuddy(CBuddy);
                CBuddy.Y--;
                if (CBuddy.printDirection == "right")
                {
                    printBuddy(Buddy, CBuddy);
                }
                else
                {
                    printBuddyLeft(BuddyLeft, CBuddy);
                }
            }

        }

        static void moveBuddyLeft(char[,] Maze, char[,] BuddyLeft, FBuddy CBuddy, ref bool game)
        {
            CBuddy.printDirection = "left";
            char next = Maze[CBuddy.Y, CBuddy.X - 1];
            char next1 = Maze[CBuddy.Y + 1, CBuddy.X - 1];
            char next2 = Maze[CBuddy.Y + 2, CBuddy.X - 1];
            if (next == ' ' && next1 == ' ' && next2 == ' ')
            {
                eraseBuddy(CBuddy);
                CBuddy.X--;
                printBuddyLeft(BuddyLeft, CBuddy);
            }
            if (next == '$' || next1 == '$' || next2 == '$')
            {
                score = score + 10;
                eraseBuddy(CBuddy);
                CBuddy.X--;
                printBuddyLeft(BuddyLeft, CBuddy);
            }
        }

        static void moveBuddyRight(char[,] Maze, char[,] Buddy, FBuddy CBuddy, ref bool game, Enemy1 CEnemy1)
        {
            CBuddy.printDirection = "right";
            char next = Maze[CBuddy.Y, CBuddy.X + 4];
            char next1 = Maze[CBuddy.Y + 1, CBuddy.X + 4];
            char next2 = Maze[CBuddy.Y + 2, CBuddy.X + 4];
            if (next == ' ' && next1 == ' ' && next2 == ' ')
            {
                eraseBuddy(CBuddy);
                CBuddy.X++;
                printBuddy(Buddy, CBuddy);
            }
            if (next == '$' || next1 == '$' || next2 == '$')
            {
                score = score + 10;
                eraseBuddy(CBuddy);
                CBuddy.X++;
                printBuddy(Buddy, CBuddy);
            }

            if ((next == '|' || next1 == '|' || next2 == '|') && CEnemy1.health == -1)
            {
                eraseBuddy(CBuddy);
                complete(ref game);
            }
        }

        static void controlBuddy(char[,] Maze, char[,] Buddy, char[,] BuddyLeft, FBuddy CBuddy, List<Bullet> B, ref bool game, Enemy1 CEnemy1)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveBuddyLeft(Maze, BuddyLeft, CBuddy, ref game);
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveBuddyRight(Maze, Buddy, CBuddy, ref game, CEnemy1);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                if (canJump(Maze, CBuddy))
                {
                    CBuddy.isJump = true;
                }
            }
            if (CBuddy.isJump)
            {
                moveBuddyUp(Maze, Buddy, BuddyLeft, CBuddy);
                CBuddy.jumpTick += 1;
                if (CBuddy.jumpTick == 4)
                {
                    CBuddy.isJump = false;
                    CBuddy.jumpTick = 0;
                }
            }
            else
            {
                moveBuddyDown(Maze, Buddy, BuddyLeft, CBuddy);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                createBullet(Maze, CBuddy, B);
            }
        }
        static bool canJump(char[,] Maze, FBuddy CBuddy)
        {
            char below1 = Maze[CBuddy.Y + 3, CBuddy.X];
            char below2 = Maze[CBuddy.Y + 3, CBuddy.X + 1];
            char below3 = Maze[CBuddy.Y + 3, CBuddy.X + 2];
            char below4 = Maze[CBuddy.Y + 3, CBuddy.X + 3];
            if ((below1 == '#' || below2 == '#' || below3 == '#' || below4 == '#'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void printBuddy(char[,] Buddy, FBuddy CBuddy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int PrintBX = CBuddy.X;
            int PrintBY = CBuddy.Y;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(PrintBX, PrintBY);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(Buddy[i, j]);
                }
                Console.WriteLine();
                PrintBY++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void eraseBuddy(FBuddy CBuddy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int PrintBX = CBuddy.X;
            int PrintBY = CBuddy.Y;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(PrintBX, PrintBY);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                PrintBY++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void printBuddyLeft(char[,] BuddyLeft, FBuddy CBuddy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int PrintBX = CBuddy.X;
            int PrintBY = CBuddy.Y;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(PrintBX, PrintBY);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(BuddyLeft[i, j]);
                }
                Console.WriteLine();
                PrintBY++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintEnemy1(char[,] Enemy, Enemy1 CEnemy1)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int EnemyP1X = CEnemy1.X;
            int EnemyP1Y = CEnemy1.Y;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(EnemyP1X, EnemyP1Y);
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(Enemy[i, j]);
                }
                Console.WriteLine();
                EnemyP1Y++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void EraseEnemy1(Enemy1 CEnemy1)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int EnemyP1X = CEnemy1.X;
            int EnemyP1Y = CEnemy1.Y;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(EnemyP1X, EnemyP1Y);
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                EnemyP1Y++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void createBullet(char[,] Maze, FBuddy CBuddy, List<Bullet> B)
        {
            if (CBuddy.printDirection == "right")
            {
                char next = Maze[CBuddy.Y + 1, CBuddy.X + 4];
                if (next == ' ')
                {
                    Console.Beep();
                    int bulletX = CBuddy.X + 4;
                    int bulletY = CBuddy.Y + 1;
                    char bulletDirection = 'R';
                    Console.SetCursorPosition(CBuddy.X + 4, CBuddy.Y + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*");
                    Bullet bullet = new Bullet(bulletX,bulletY,bulletDirection);
                    B.Add(bullet);
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }

            if (CBuddy.printDirection == "left")
            {
                char next = Maze[CBuddy.Y + 1, CBuddy.X - 1];
                if (next == ' ')
                {
                    Console.Beep();
                    int bulletX = CBuddy.X - 1;
                    int bulletY = CBuddy.Y + 1;
                    char bulletDirection = 'L';
                    Console.SetCursorPosition(CBuddy.X - 1, CBuddy.Y + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*");
                    Bullet bullet = new Bullet(bulletX, bulletY, bulletDirection);
                    B.Add(bullet);
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
        }
        static void movebullet(char[,] Maze, List<Bullet> B)
        {
            for (int x = 0; x < B.Count; x++)
            {
                if (B[x].BulletDirection == 'R')
                {
                    char next = Maze[B[x].Y, B[x].X + 1];
                    if (next != ' ')
                    {
                        eraseBullet(B[x].X, B[x].Y);
                        deleteBullet(x, B);
                    }
                    else
                    {
                        eraseBullet(B[x].X, B[x].Y);
                        B[x].X++;
                        printBullet(B[x].X, B[x].Y);
                    }
                }

                else if (B[x].BulletDirection == 'L')
                {
                    char next = Maze[B[x].Y, B[x].X - 1];
                    if (next != ' ')
                    {
                        eraseBullet(B[x].X, B[x].Y);
                        deleteBullet(x, B);
                    }
                    else
                    {
                        eraseBullet(B[x].X, B[x].Y);
                        B[x].X--;
                        printBullet(B[x].X, B[x].Y);
                    }
                }
            }
        }

        static void deleteBullet(int index,  List<Bullet> B)
        {
            B.RemoveAt(index);
        }

        static void printBullet(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("*");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void eraseBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }
        static void moveEnemy(char[,] Maze, char[,] Enemy, Enemy1 CEnemy1)
        {
            if (CEnemy1.health > 0)
            {
                if (CEnemy1.direction == "up")
                {
                    char next = Maze[CEnemy1.Y - 1, CEnemy1.X];
                    if (next == ' ')
                    {
                        EraseEnemy1(CEnemy1);
                        CEnemy1.Y--;
                        PrintEnemy1(Enemy, CEnemy1);
                    }
                    if (next == '#')
                    {
                        CEnemy1.direction = "down";
                    }
                }
                if (CEnemy1.direction == "down")
                {
                    char next = Maze[CEnemy1.Y + 3, CEnemy1.X];
                    if (next == ' ')
                    {
                        EraseEnemy1(CEnemy1);
                        CEnemy1.Y++;
                        PrintEnemy1(Enemy, CEnemy1);
                    }
                    if (next == '#')
                    {
                        CEnemy1.direction = "up";
                    }
                }
            }
            if (CEnemy1.health == 0)
            {
                EraseEnemy1(CEnemy1);
                CEnemy1.health = -1;
                CEnemy1.X = 0;
                CEnemy1.Y = 0;
                Console.SetCursorPosition(75, 12);
                Console.WriteLine("Botchan Health: KILL ");
            }
        }
        static void gameover(FBuddy CBuddy, ref bool game)
        {
            if (CBuddy.health == 0)
            {
                game = false;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(20, 15);
                Console.WriteLine("GAME OVER");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(300);
            }
        }
        static void complete(ref bool game)
        {
            game = false;
            // game2 = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 15);
            Console.WriteLine("STAGE COMLETE :)");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(300);
        }
        static void gameoverCollsion(FBuddy CBuddy, Enemy1 CEnemy1)
        {
            // enemy1

            if (CEnemy1.health > 0)
            {
                for (int i = -2; i < 3; i++) // right
                {
                    if (CBuddy.X + 3 == CEnemy1.X - 1 && CBuddy.Y == CEnemy1.Y + i)
                    {
                        CBuddy.health = 0;
                    }
                }

                if (CBuddy.X + 3 == CEnemy1.X - 1 && CBuddy.Y == CEnemy1.Y) // right
                {
                    CBuddy.health = 0;
                }

                for (int i = -3; i < 8; i++) // enemy up
                {
                    if (CBuddy.X == CEnemy1.X + i && CBuddy.Y - 1 == CEnemy1.Y + 2)
                    {
                        CBuddy.health = 0;
                    }
                }

                for (int i = -3; i < 8; i++) // Enemy down
                {
                    if (CBuddy.X == CEnemy1.X + i && CBuddy.Y + 2 == CEnemy1.Y - 1)
                    {
                        CBuddy.health = 0;
                    }
                }
            }
        }
        static void printBuddyHealth(FBuddy CBuddy)
        {

            Console.SetCursorPosition(75, 10);
            Console.WriteLine("Your Health:    ");
            Console.SetCursorPosition(75, 10);
            Console.WriteLine("Your Health: " + CBuddy.health);
        }
        static void Printenemyhealth(ref bool game, Enemy1 CEnemy1)
        {
            if (CEnemy1.health > 0 && game == true)
            {
                Console.SetCursorPosition(75, 12);
                Console.WriteLine("Botchan Health:   ");
                Console.SetCursorPosition(75, 12);
                Console.WriteLine("Botchan Health: " + CEnemy1.health);
            }
        }
        static void printScore()
        {
            Console.SetCursorPosition(75, 8);
            Console.WriteLine("Score: " + score);
        }
        static void addScore()
        {
            score++;
        }
        static void LoadMaze(char[,] Maze)
        {
            StreamReader fp = new StreamReader("Maze.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 70; x++)
                {
                    Maze[row, x] = record[x];
                }
                row++;
            }

            fp.Close();
        }
        static void LoadBuddy(char[,] Buddy)
        {
            char fireBuddyHead = Convert.ToChar(234);
            char fireBuddyBody = Convert.ToChar(178);
            char fireBuddyHand = Convert.ToChar(155);
            StreamReader fp = new StreamReader("BuddyRight.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 4; x++)
                {
                    Buddy[row, x] = record[x];
                    if (record[x] == 'H')
                    {
                        Buddy[row, x] = 'Ω';
                    }
                    else if (record[x] == 'B')
                    {
                        Buddy[row, x] = '▓';
                    }
                    else if (record[x] == 'L')
                    {
                        Buddy[row, x] = '¢';
                    }
                    else
                    {
                        Buddy[row, x] = record[x];
                    }
                }
                row++;
            }

            fp.Close();
        }
        static void LoadBuddyLeft(char[,] BuddyLeft)
        {
            char fireBuddyHead = Convert.ToChar(234);
            char fireBuddyBody = Convert.ToChar(178);
            char fireBuddyHand = Convert.ToChar(155);
            StreamReader fp = new StreamReader("BuddyLeft.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 4; x++)
                {
                    BuddyLeft[row, x] = record[x];
                    if (record[x] == 'H')
                    {
                        BuddyLeft[row, x] = 'Ω';
                    }
                    else if (record[x] == 'B')
                    {
                        BuddyLeft[row, x] = '▓';
                    }
                    else if (record[x] == 'L')
                    {
                        BuddyLeft[row, x] = '¢';
                    }
                    else
                    {
                        BuddyLeft[row, x] = record[x];
                    }
                }
                row++;
            }

            fp.Close();
        }
        static void LoadEnemy(char[,] Enemy)
        {
            StreamReader fp = new StreamReader("Enemy.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int i = 0; i < 5; i++)
                {
                    Enemy[row, i] = record[i];
                }
                row++;
            }
            fp.Close();
        }
        static void collision(Enemy1 CEnemy1, List<Bullet> B, ref int score)
        {
            for (int x = 0; x < B.Count; x++)
            {
                if (CEnemy1.health > 0)
                {
                    if (B[x].X + 1 == CEnemy1.X && (B[x].Y == CEnemy1.Y || B[x].Y == CEnemy1.Y + 1 || B[x].Y == CEnemy1.Y + 2))
                    {
                        eraseBullet(B[x].X, B[x].Y);
                        CEnemy1.health = CEnemy1.health - 5;
                        addScore();
                        deleteBullet(x, B);
                    }
                }
            }
        }
    }
}
