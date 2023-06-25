using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GL
{
    public class GameCell
    {
        public int x;
        public int y;
        public GameObject currentGameObject;
        public GameGrid gameGrid;

        public GameCell(int x, int y, GameGrid grid)
        {
            this.x = x;
            this.y = y;
            gameGrid = grid;
        }

        public GameCell()
        {
            x = 0;
            y = 0;
        }

        public GameCell nextCell(GameDirection direction)
        {
            if (direction == GameDirection.UP)
            {
                return gameGrid.GetCell(y, x - 1);
            }
            else if (direction == GameDirection.DOWN)
            {
                return gameGrid.GetCell(y, x + 1);
            }
            else if (direction == GameDirection.LEFT)
            {
                return gameGrid.GetCell(y - 1, x);
            }
            else if (direction == GameDirection.RIGHT)
            {
                return gameGrid.GetCell(y + 1, x);
            }
            return null;
        }
    }
}
