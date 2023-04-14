using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using EZInput;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] Maze = new char[26, 70]; // All Arrays
            char[,] Buddy = new char[3, 4];
            char[,] BuddyLeft = new char[3, 4];
            char[,] Enemy = new char[3, 5];
            LoadMaze(Maze);
            LoadBuddy(Buddy);
            LoadBuddyLeft(BuddyLeft);
            LoadEnemy(Enemy);


            int BuddyX = 3;
            int BuddyY = 22;
            int Buddyhealth = 100;
            string printDirection = "right";
            bool isJump = false;
            int jumpTick = 0;

            int[] bulletX = new int[100];
            int[] bulletY = new int[100];
            char[] bulletDirection = new char[100];
            int bulletCount = 0;

            int enemy1X = 62; // enemy1 coordinates and health
            int enemy1Y = 22;
            string enemy1direction = "down";
            int Enemy1health = 50;

            int score = 0; // score

            int check = 0; // flags for game
            bool game = true;
            int count = 0;
            int tick = 0;

            Console.Clear();
            PrintMaze(Maze);
            PrintEnemy1(Enemy, ref enemy1X, ref enemy1Y);
            printBuddy(Buddy, ref BuddyX, ref BuddyY);

            while (game)
            {
                printScore(ref score);
                printBuddyHealth(ref Buddyhealth);
                moveEnemy(Maze, Enemy, ref enemy1X, ref enemy1Y, ref Enemy1health, ref enemy1direction);
                gameover(ref Buddyhealth, ref game);
                gameoverCollsion(ref BuddyX, ref BuddyY, ref Buddyhealth, ref enemy1X, ref enemy1Y, ref Enemy1health);
                Printenemyhealth(ref game, ref Enemy1health);
                controlBuddy(Maze, Buddy, BuddyLeft, ref BuddyX, ref BuddyY, ref printDirection, ref isJump, ref jumpTick, bulletX, bulletY, bulletDirection, ref bulletCount, ref check, ref game, ref score, ref Enemy1health, ref Buddyhealth);
                movebullet(Maze, bulletX, bulletY, bulletDirection, ref bulletCount);
                collision(ref Buddyhealth, ref enemy1X, ref enemy1Y, bulletX, bulletY, bulletDirection, ref bulletCount, ref Enemy1health, ref score);
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
        static void moveBuddyDown(char[,] Maze, char[,] Buddy, char[,] BuddyLeft, ref int BuddyX, ref int BuddyY, ref string printDirection, ref int score)
        {
            char next = Maze[BuddyY + 3, BuddyX];
            char next1 = Maze[BuddyY + 3, BuddyX + 1];
            char next2 = Maze[BuddyY + 3, BuddyX + 2];
            char next3 = Maze[BuddyY + 3, BuddyX + 3];
            if (next == ' ' && next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseBuddy(ref BuddyX, ref BuddyY);
                BuddyY++;
                if (printDirection == "right")
                {
                    printBuddy(Buddy, ref BuddyX, ref BuddyY);
                }
                else
                {
                    printBuddyLeft(BuddyLeft, ref BuddyX, ref BuddyY);
                }
            }

            else if (next == '$' || next1 == '$' || next2 == '$' || next3 == '$')
            {
                score = score + 10;
                eraseBuddy(ref BuddyX, ref BuddyY);
                BuddyY++;
                if (printDirection == "right")
                {
                    printBuddy(Buddy, ref BuddyX, ref BuddyY);
                }
                else
                {
                    printBuddyLeft(BuddyLeft, ref BuddyX, ref BuddyY);
                }
            }
        }

        static void moveBuddyUp(char[,] Maze, char[,] Buddy, char[,] BuddyLeft, ref int BuddyX, ref int BuddyY, ref string printDirection, ref int score, ref int Buddyhealth)
        {
            char next = Maze[BuddyY - 1, BuddyX];
            char next1 = Maze[BuddyY - 1, BuddyX + 1];
            char next2 = Maze[BuddyY - 1, BuddyX + 2];
            char next3 = Maze[BuddyY - 1, BuddyX + 3];
            if (next == ' ' && next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseBuddy(ref BuddyX, ref BuddyY);
                BuddyY--;
                if (printDirection == "right")
                {
                    printBuddy(Buddy, ref BuddyX, ref BuddyY);
                }
                else
                {
                    printBuddyLeft(BuddyLeft, ref BuddyX, ref BuddyY);
                }
            }

            if (next == '$' || next1 == '$' || next2 == '$' || next3 == '$')
            {
                score = score + 10;
                eraseBuddy(ref BuddyX, ref BuddyY);
                BuddyY--;
                if (printDirection == "right")
                {
                    printBuddy(Buddy, ref BuddyX, ref BuddyY);
                }
                else
                {
                    printBuddyLeft(BuddyLeft, ref BuddyX, ref BuddyY);
                }
            }

        }

        static void moveBuddyLeft(char[,] Maze, char[,] BuddyLeft, ref int BuddyX, ref int BuddyY, ref string printDirection, ref int check, ref bool game, ref int score)
        {
            printDirection = "left";
            char next = Maze[BuddyY, BuddyX - 1];
            char next1 = Maze[BuddyY + 1, BuddyX - 1];
            char next2 = Maze[BuddyY + 2, BuddyX - 1];
            if (next == ' ' && next1 == ' ' && next2 == ' ')
            {
                eraseBuddy(ref BuddyX, ref BuddyY);
                BuddyX--;
                printBuddyLeft(BuddyLeft, ref BuddyX, ref BuddyY);
            }
            if (next == '$' || next1 == '$' || next2 == '$')
            {
                score = score + 10;
                eraseBuddy(ref BuddyX, ref BuddyY);
                BuddyX--;
                printBuddyLeft(BuddyLeft, ref BuddyX, ref BuddyY);
            }
        }

        static void moveBuddyRight(char[,] Maze, char[,] Buddy, ref int BuddyX, ref int BuddyY, ref string printDirection, ref int check, ref bool game, ref int score, ref int Enemy1health)
        {
            printDirection = "right";
            char next = Maze[BuddyY, BuddyX + 4];
            char next1 = Maze[BuddyY + 1, BuddyX + 4];
            char next2 = Maze[BuddyY + 2, BuddyX + 4];
            if (next == ' ' && next1 == ' ' && next2 == ' ')
            {
                eraseBuddy(ref BuddyX, ref BuddyY);
                BuddyX++;
                printBuddy(Buddy, ref BuddyX, ref BuddyY);
            }
            if (next == '$' || next1 == '$' || next2 == '$')
            {
                score = score + 10;
                eraseBuddy(ref BuddyX, ref BuddyY);
                BuddyX++;
                printBuddy(Buddy, ref BuddyX, ref BuddyY);
            }

            if ((next == '|' || next1 == '|' || next2 == '|') && Enemy1health == -1)
            {
                eraseBuddy(ref BuddyX, ref BuddyY);
                complete(ref check, ref game);
            }
        }

        static void controlBuddy(char[,] Maze, char[,] Buddy, char[,] BuddyLeft, ref int BuddyX, ref int BuddyY, ref string printDirection, ref bool isJump, ref int jumpTick, int[] bulletX, int[] bulletY, char[] bulletDirection, ref int bulletCount, ref int check, ref bool game, ref int score, ref int Enemy1health, ref int Buddyhealth)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveBuddyLeft(Maze, BuddyLeft, ref BuddyX, ref BuddyY, ref printDirection, ref check, ref game, ref score);
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveBuddyRight(Maze, Buddy, ref BuddyX, ref BuddyY, ref printDirection, ref check, ref game, ref score, ref Enemy1health);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                if (canJump(Maze, ref BuddyX, ref BuddyY))
                {
                    isJump = true;
                }
            }
            if (isJump)
            {
                moveBuddyUp(Maze, Buddy, BuddyLeft, ref BuddyX, ref BuddyY, ref printDirection, ref score, ref Buddyhealth);
                jumpTick += 1;
                if (jumpTick == 4)
                {
                    isJump = false;
                    jumpTick = 0;
                }
            }
            else
            {
                moveBuddyDown(Maze, Buddy, BuddyLeft, ref BuddyX, ref BuddyY, ref printDirection, ref score);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                createBullet(Maze, ref BuddyX, ref BuddyY, ref printDirection, bulletX, bulletY, bulletDirection, ref bulletCount);
            }
        }
        static bool canJump(char[,] Maze, ref int BuddyX, ref int BuddyY)
        {
            char below1 = Maze[BuddyY + 3, BuddyX];
            char below2 = Maze[BuddyY + 3, BuddyX + 1];
            char below3 = Maze[BuddyY + 3, BuddyX + 2];
            char below4 = Maze[BuddyY + 3, BuddyX + 3];
            if ((below1 == '#' || below2 == '#' || below3 == '#' || below4 == '#'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void printBuddy(char[,] Buddy, ref int BuddyX, ref int BuddyY)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int PrintBX = BuddyX;
            int PrintBY = BuddyY;
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
        static void eraseBuddy(ref int BuddyX, ref int BuddyY)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int PrintBX = BuddyX;
            int PrintBY = BuddyY;
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
        static void printBuddyLeft(char[,] BuddyLeft, ref int BuddyX, ref int BuddyY)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int PrintBX = BuddyX;
            int PrintBY = BuddyY;
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

        static void PrintEnemy1(char[,] Enemy, ref int enemy1X, ref int enemy1Y)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int EnemyP1X = enemy1X;
            int EnemyP1Y = enemy1Y;
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
        static void EraseEnemy1(ref int enemy1X, ref int enemy1Y)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int EnemyP1X = enemy1X;
            int EnemyP1Y = enemy1Y;
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
        static void createBullet(char[,] Maze, ref int BuddyX, ref int BuddyY, ref string printDirection, int[] bulletX, int[] bulletY, char[] bulletDirection, ref int bulletCount)
        {
            if (printDirection == "right")
            {
                Console.Beep();
                char next = Maze[BuddyY + 1, BuddyX + 4];
                if (next == ' ')
                {
                    bulletX[bulletCount] = BuddyX + 4;
                    bulletY[bulletCount] = BuddyY + 1;
                    bulletDirection[bulletCount] = 'R';
                    Console.SetCursorPosition(BuddyX + 4, BuddyY + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*");
                    bulletCount++;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }

            if (printDirection == "left")
            {
                Console.Beep();
                char next = Maze[BuddyY + 1, BuddyX - 1];
                if (next == ' ')
                {
                    bulletX[bulletCount] = BuddyX - 1;
                    bulletY[bulletCount] = BuddyY + 1;
                    bulletDirection[bulletCount] = 'L';
                    Console.SetCursorPosition(BuddyX - 1, BuddyY + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*");
                    bulletCount++;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
        }
        static void movebullet(char[,] Maze, int[] bulletX, int[] bulletY, char[] bulletDirection, ref int bulletCount)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (bulletDirection[x] == 'R')
                {
                    char next = Maze[bulletY[x], bulletX[x] + 1];
                    if (next != ' ')
                    {
                        eraseBullet(bulletX[x], bulletY[x]);
                        deleteBullet(x, bulletX, bulletY, bulletDirection, ref bulletCount);
                    }
                    else
                    {
                        eraseBullet(bulletX[x], bulletY[x]);
                        bulletX[x]++;
                        printBullet(bulletX[x], bulletY[x]);
                    }
                }

                if (bulletDirection[x] == 'L')
                {
                    char next = Maze[bulletY[x], bulletX[x] - 1];
                    if (next != ' ')
                    {
                        eraseBullet(bulletX[x], bulletY[x]);
                        deleteBullet(x, bulletX, bulletY, bulletDirection, ref bulletCount);
                    }
                    else
                    {
                        eraseBullet(bulletX[x], bulletY[x]);
                        bulletX[x]--;
                        printBullet(bulletX[x], bulletY[x]);
                    }
                }
            }
        }

        static void deleteBullet(int index, int[] bulletX, int[] bulletY, char[] bulletDirection, ref int bulletCount)
        {
            int x = index;
            while (x < bulletCount)
            {
                bulletX[x] = bulletX[x + 1];
                bulletY[x] = bulletY[x + 1];
                bulletDirection[x] = bulletDirection[x + 1];
                x++;
            }
            bulletCount--;
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
        static void moveEnemy(char[,] Maze, char[,] Enemy, ref int enemy1X, ref int enemy1Y, ref int Enemy1health, ref string enemy1direction)
        {
            if (Enemy1health > 0)
            {
                if (enemy1direction == "up")
                {
                    char next = Maze[enemy1Y - 1, enemy1X];
                    if (next == ' ')
                    {
                        EraseEnemy1(ref enemy1X, ref enemy1Y);
                        enemy1Y--;
                        PrintEnemy1(Enemy, ref enemy1X, ref enemy1Y);
                    }
                    if (next == '#')
                    {
                        enemy1direction = "down";
                    }
                }
                if (enemy1direction == "down")
                {
                    char next = Maze[enemy1Y + 3, enemy1X];
                    if (next == ' ')
                    {
                        EraseEnemy1(ref enemy1X, ref enemy1Y);
                        enemy1Y++;
                        PrintEnemy1(Enemy, ref enemy1X, ref enemy1Y);
                    }
                    if (next == '#')
                    {
                        enemy1direction = "up";
                    }
                }
            }
            if (Enemy1health == 0)
            {
                EraseEnemy1(ref enemy1X, ref enemy1Y);
                Enemy1health = -1;
                enemy1X = 0;
                enemy1Y = 0;
                Console.SetCursorPosition(75, 12);
                Console.WriteLine("Botchan Health: KILL ");
            }
        }
        static void gameover(ref int Buddyhealth, ref bool game)
        {
            if (Buddyhealth == 0)
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
            }
        }
        static void complete(ref int check, ref bool game)
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
        }
        static void gameoverCollsion(ref int BuddyX, ref int BuddyY, ref int Buddyhealth, ref int enemy1X, ref int enemy1Y, ref int Enemy1health)
        {
            // enemy1
            if (Enemy1health > 0)
            {
                for (int i = -2; i < 3; i++) // right
                {
                    if (BuddyX + 3 == enemy1X - 1 && BuddyY == enemy1Y + i)
                    {
                        Buddyhealth = 0;
                    }
                }

                if (BuddyX + 3 == enemy1X - 1 && BuddyY == enemy1Y) // right
                {
                    Buddyhealth = 0;
                }

                for (int i = -3; i < 8; i++) // enemy up
                {
                    if (BuddyX == enemy1X + i && BuddyY - 1 == enemy1Y + 2)
                    {
                        Buddyhealth = 0;
                    }
                }

                for (int i = -3; i < 8; i++) // Enemy down
                {
                    if (BuddyX == enemy1X + i && BuddyY + 2 == enemy1Y - 1)
                    {
                        Buddyhealth = 0;
                    }
                }
            }
        }
        static void printBuddyHealth(ref int Buddyhealth)
        {
            Console.SetCursorPosition(75, 10);
            Console.WriteLine("Your Health:    ");
            Console.SetCursorPosition(75, 10);
            Console.WriteLine("Your Health: " + Buddyhealth);
        }
        static void Printenemyhealth(ref bool game, ref int Enemy1health)
        {
            if (Enemy1health > 0 && game == true)
            {
                Console.SetCursorPosition(75, 12);
                Console.WriteLine("Botchan Health:   ");
                Console.SetCursorPosition(75, 12);
                Console.WriteLine("Botchan Health: " + Enemy1health);
            }
        }
        static void printScore(ref int score)
        {
            Console.SetCursorPosition(75, 8);
            Console.WriteLine("Score: " + score);
        }
        static void addScore(ref int score)
        {
            score++;
        }
        static void LoadMaze(char[,] Maze)
        {
            StreamReader fp = new StreamReader("D:\\GitHub\\PD2\\Week01\\Task02\\Task02\\Maze.txt");
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
            StreamReader fp = new StreamReader("D:\\GitHub\\PD2\\Week01\\Task02\\Task02\\BuddyRight.txt");
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
            StreamReader fp = new StreamReader("D:\\GitHub\\PD2\\Week01\\Task02\\Task02\\BuddyLeft.txt");
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
            StreamReader fp = new StreamReader("D:\\GitHub\\PD2\\Week01\\Task02\\Task02\\Enemy.txt");
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
        static void collision(ref int Buddyhealth,ref int enemy1X,ref int enemy1Y, int[] bulletX, int[] bulletY, char[] bulletDirection,ref int bulletCount,ref int Enemy1health,ref int score)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (Enemy1health > 0)
                {
                    if (bulletX[x] + 1 == enemy1X && (bulletY[x] == enemy1Y || bulletY[x] == enemy1Y + 1 || bulletY[x] == enemy1Y + 2))
                    {
                        eraseBullet(bulletX[x], bulletY[x]);
                        Enemy1health = Enemy1health - 5;
                        addScore(ref score);
                        deleteBullet(x, bulletX, bulletY, bulletDirection,ref bulletCount);
                    }
                }
            }
        }
    }
}
