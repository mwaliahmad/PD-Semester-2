using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GL
{
    public class VGhost : Ghost
    {
        public VGhost(char displayCharacter, GameCell cell) : base(displayCharacter, cell)
        {

        }
        public override void Move(ref GameDirection direction)
        {
            if (direction == GameDirection.UP)
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
                    direction = GameDirection.DOWN;
                }
            }
            else if (direction == GameDirection.DOWN)
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
                    direction = GameDirection.UP;
                }
            }
        }
    }
}
