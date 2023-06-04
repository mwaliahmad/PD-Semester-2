using Problem01.BL;
using System.IO;

namespace Problem01.DL
{
    public class GridCRUD
    {
        public static Cell[,] LoadMaze(int SRow, int SCol, string path)
        {
            Cell[,] Maze = new Cell[SRow,SCol];
            int row = 0;
            int col = 0;
            StreamReader File = new StreamReader(path);
            char character = ' ';
            while (!File.EndOfStream)
            {
                character = (char)File.Read();
                if (character == '\r')
                    continue;
                if (character == '\n')
                {
                    row++;
                    col = 0;
                }
                else
                {
                    Maze[row, col] = new Cell(character, row, col);
                    col++;
                }
            }
            File.Close();
            return Maze;
        }
    }
}
