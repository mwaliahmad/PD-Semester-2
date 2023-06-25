using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pacman.GL
{
    public abstract class Ghost : GameObject
    {
        public abstract void Move(ref GameDirection direction);

        public Ghost(char p, GameCell start)
        {
            displayCharacter = p;
            currentCell = start;
            currentCell.currentGameObject = this;
        }
    }
}
