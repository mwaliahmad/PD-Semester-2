using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem01.BL;

namespace Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Maze.txt";
            Grid Maze = new Grid(10, 10, path);
            Maze.DrawMaze();
        }
    }
}
