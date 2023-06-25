using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GL
{
    public class HGhost : Ghost
    {
        public HGhost(char p, GameCell start) : base(p, start)
        {

        }
        public override void Move(ref GameDirection direction)
        {
            if (direction == GameDirection.RIGHT)
            {
                GameCell c = currentCell.nextCell(direction);
                if (c.currentGameObject.displayCharacter == ' ' || c.currentGameObject.displayCharacter == '.')
                {
                    if (c.currentGameObject.displayCharacter == '.')
                    {
                        Program.moveGameObject(this, direction, '.');
                    }
                    else
                    {
                        Program.moveGameObject(this, direction);
                    }
                }
                else
                {
                    direction = GameDirection.LEFT;
                }
            }
            else if (direction == GameDirection.LEFT)
            {
                GameCell c = currentCell.nextCell(direction);
                if (c.currentGameObject.displayCharacter == ' ' || c.currentGameObject.displayCharacter == '.')
                {
                    if (c.currentGameObject.displayCharacter == '.')
                    {
                        Program.moveGameObject(this, direction, '.');
                    }
                    else
                    {
                        Program.moveGameObject(this, direction);
                    }
                }
                else
                {
                    direction = GameDirection.RIGHT;
                }
            }
        }
    }
}
