using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem01.DL;
namespace Problem01.BL
{
    public class Grid
    {
        public Grid(int RowSize, int ColumnSize, string path)
        {
            this.Maze = GridCRUD.LoadMaze(RowSize, ColumnSize, path);
            this.RowSize = RowSize;
            this.ColumnSize = ColumnSize;
        }

        public Cell[,] Maze;
        public int RowSize;
        public int ColumnSize;

        public Cell GetLeftCell(Cell c)
        {
            int newX = c.GetX() - 1;
            int newY = c.GetY();
            char newValue = c.GetChar();
            Cell newCell = new Cell(newValue, newX, newY);
            return newCell;
        }
        public Cell GetRightCell(Cell c)
        {
            int newX = c.GetX() + 1;
            int newY = c.GetY();
            char newValue = c.GetChar();
            Cell newCell = new Cell(newValue, newX, newY);
            return newCell;
        }
        public Cell GetUpCell(Cell c)
        {
            int newX = c.GetX();
            int newY = c.GetY() - 1;
            char newValue = c.GetChar();
            Cell newCell = new Cell(newValue, newX, newY);
            return newCell;
        }
        public Cell GetDownCell(Cell c)
        {
            int newX = c.GetX();
            int newY = c.GetY() + 1;
            char newValue = c.GetChar();
            Cell newCell = new Cell(newValue, newX, newY);
            return newCell;
        }
        public Cell FindPacman()
        {
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColumnSize; j++)
                {
                    if(Maze[i,j].GetChar() == 'P')
                    {
                        return Maze[i,j];
                    }
                }
            }
            return null;
        }
        public Cell FindGhost(char ghostchar)
        {
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColumnSize; j++)
                {
                    if (Maze[i, j].GetChar() == ghostchar)
                    {
                        return Maze[i, j];
                    }
                }
            }
            return null;
        }
        /*public bool IsStop()
        {

        }*/
        public void DrawMaze()
        {
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColumnSize; j++)
                {
                    Console.Write(Maze[i, j].GetChar());
                }
                Console.WriteLine();
            }
        }
    }
}
