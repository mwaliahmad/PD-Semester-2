using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Pacman.GL
{
    public class GameGrid
    {
        public GameCell[,] gameCells;
        public int rows;
        public int columns;

        public GameGrid(string filename, int rows, int columns)
        {
            this.columns = columns;
            this.rows = rows;
            gameCells = new GameCell[rows, columns];
            loadGrid(filename);
        }

        public void loadGrid(string filename)
        {
            if (File.Exists(filename))
            {
                GameObject temp = new GameObject();
                StreamReader file = new StreamReader(filename);
                string record;
                for (int i = 0; i < this.rows; i++)
                {
                    record = file.ReadLine();
                    for (int j = 0; j < this.columns; j++)
                    {
                        GameCell cell = new GameCell(i, j, this);
                        char displayCharacter = record[j];
                        GameObjectType t = GameObject.GetGameObjectType(displayCharacter.ToString());
                        GameObject b = new GameObject(t, displayCharacter);
                        cell.currentGameObject = b;
                        gameCells[i, j] = cell;
                    }
                }

                file.Close();
            }
        }

        public GameCell GetCell(int x, int y)
        {
            return gameCells[y, x];
        }
    }
}