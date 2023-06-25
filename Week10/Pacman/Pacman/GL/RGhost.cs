using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GL
{
    public class RGhost : Ghost
    {
        public RGhost(char p, GameCell start) : base(p, start)
        {

        }
        public override void Move(ref GameDirection direction)
        {
            GameDirection[] directions = { GameDirection.UP, GameDirection.DOWN, GameDirection.LEFT, GameDirection.RIGHT };
            Random rnd = new Random();
            int i = rnd.Next(4);
            direction = directions[i];
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
            else if (direction == GameDirection.RIGHT)
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
