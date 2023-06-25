using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;
using Pacman.GL;

namespace Pacman
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameGrid grid = new GameGrid("maze.txt", 24, 71);
            GameCell start = new GameCell(12, 22, grid);
            GameCell Start1 = new GameCell(15, 39, grid);
            GameCell Start2 = new GameCell(20, 57, grid);
            GameCell Start3 = new GameCell(19, 25, grid);
            GameCell Start4 = new GameCell(21, 30, grid);
            PacmanPlayer pacman = new PacmanPlayer('P', start);
            HGhost Ghost1 = new HGhost('H', Start1);
            VGhost Ghost2 = new VGhost('V', Start2);
            RGhost Ghost3 = new RGhost('R', Start3);
            SGhost Ghost4 = new SGhost('S', Start4);
            GameDirection direction = GameDirection.RIGHT;
            GameDirection direction2 = GameDirection.UP;
            GameDirection direction3 = GameDirection.DOWN;
            GameDirection direction4 = GameDirection.DOWN;
            int count = 0;
            printMaze(grid);
            printGameObject(pacman);
            printGameObject(Ghost1);
            printGameObject(Ghost2);
            while (true)
            {
                count++;
                // printScore(pacman);
                Thread.Sleep(90);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    clearGameCellContent(pacman.currentCell, pacman);
                    pacman.move(GameDirection.UP);
                    printGameObject(pacman);
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    clearGameCellContent(pacman.currentCell, pacman);
                    pacman.move(GameDirection.DOWN);
                    printGameObject(pacman);
                }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    clearGameCellContent(pacman.currentCell, pacman);
                    pacman.move(GameDirection.RIGHT);
                    printGameObject(pacman);
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    clearGameCellContent(pacman.currentCell, pacman);
                    pacman.move(GameDirection.LEFT);
                    printGameObject(pacman);
                }
                if (count % 3 == 0)
                {
                    Ghost1.Move(ref direction);
                    Ghost2.Move(ref direction2);
                }
                if (count % 2 == 0)
                {
                    Ghost3.Move(ref direction3);
                }
                if (count % 5 == 0)
                {
                    Ghost4.SetDirection(pacman.currentCell.x, pacman.currentCell.y, ref direction4);
                }
            }
        }

        static void clearGameCellContent(GameCell gameCell, GameObject newGameObject)
        {
            gameCell.currentGameObject = newGameObject;
            Console.SetCursorPosition(gameCell.y, gameCell.x);
            Console.Write(newGameObject.displayCharacter);
        }
        static void printGameObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.currentCell.y, gameObject.currentCell.x);
            Console.Write(gameObject.displayCharacter);

        }

        public static void moveGameObject(GameObject gameObject, GameDirection direction)
        {
            GameCell nextCell = gameObject.currentCell.nextCell(direction);
            if (nextCell != null)
            {
                GameObject newGO = new GameObject(GameObjectType.NONE, ' ');
                GameCell currentCell = gameObject.currentCell;
                clearGameCellContent(currentCell, newGO);
                gameObject.currentCell = nextCell;
                printGameObject(gameObject);
            }
        }

        public static void moveGameObject(GameObject gameObject, GameDirection direction, char c)
        {
            GameCell nextCell = gameObject.currentCell.nextCell(direction);
            if (nextCell != null)
            {
                GameObject newGO = new GameObject(GameObjectType.REWARD, c);
                GameCell currentCell = gameObject.currentCell;
                clearGameCellContent(currentCell, newGO);
                gameObject.currentCell = nextCell;
                printGameObject(gameObject);
            }
        }

        static void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.rows; x++)
            {
                for (int y = 0; y < grid.columns; y++)
                {
                    GameCell cell = grid.GetCell(y, x);
                    printCell(cell);
                }

            }
        }

        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.y, cell.x);
            Console.Write(cell.currentGameObject.displayCharacter);
        }

        /*static void printScore(PacmanPlayer pacman)
        {
            int score = pacman.GetScore();
            Console.SetCursorPosition(10, 27);
            Console.WriteLine("Score :" + score);
        }*/
    }
}
