using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01.BL
{
    public class Pacman
    {
        public Pacman(int X, int Y, Grid MazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.MazeGrid = MazeGrid;
        }
        public int X;
        public int Y;
        public int Score = 0;
        public Grid MazeGrid;
        public void Remove()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('P');
        }
        public void MoveLeft(Cell current, Cell next)
        {

        }
        public void MoveRight(Cell current, Cell next)
        {

        }
        public void MoveUp(Cell current, Cell next)
        {

        }
        public void MoveDown(Cell current, Cell next)
        {
            
        }
        public void Move()
        {

        }
        public void PrintScore()
        {
            Console.SetCursorPosition(25, 10);
            Console.Write("Score: {0}", Score);
        }
    }
}
