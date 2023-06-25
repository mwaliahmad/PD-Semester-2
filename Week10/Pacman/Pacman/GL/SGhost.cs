using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GL
{
    public class SGhost : Ghost
    {
        public SGhost(char p, GameCell start) : base(p, start)
        {

        }

        public void SetDirection(int x, int y, ref GameDirection direction)
        {
            if (x > currentCell.x)
            {
                direction = GameDirection.RIGHT;
                Move(ref direction);
            }
            else if (x < currentCell.x)
            {
                direction = GameDirection.LEFT;
                Move(ref direction);
            }
            else if (y > currentCell.y)
            {
                direction = GameDirection.DOWN;
                Move(ref direction);
            }
            else if (y < currentCell.y)
            {
                direction = GameDirection.UP;
                Move(ref direction);
            }
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
            }
        }
    }
}
