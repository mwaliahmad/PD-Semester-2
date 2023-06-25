using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GL
{
    class PacmanPlayer : GameObject
    {
        int score;

        public int GetScore()
        {
            return score;
        }

        public void IncreaseScore(GameCell cell)
        {
            if (cell.currentGameObject.displayCharacter == '.')
            {
                cell.currentGameObject.displayCharacter = ' ';
                score++;
            }
        }

        public PacmanPlayer(char p, GameCell start)
        {
            displayCharacter = p;
            currentCell = start;
            currentCell.currentGameObject = this;
            score = 0;
        }
        public void move(GameDirection direction)
        {
            if (direction == GameDirection.UP)
            {
                GameCell c = currentCell.nextCell(GameDirection.UP);
                IncreaseScore(c);
                if (c.currentGameObject.displayCharacter == ' ' || c.currentGameObject.displayCharacter == '.')
                {
                    Program.moveGameObject(this, direction);
                }
            }
            else if (direction == GameDirection.DOWN)
            {
                GameCell c = currentCell.nextCell(GameDirection.DOWN);
                IncreaseScore(c);
                if (c.currentGameObject.displayCharacter == ' ' || c.currentGameObject.displayCharacter == '.')
                {
                    Program.moveGameObject(this, direction);
                }
            }
            else if (direction == GameDirection.LEFT)
            {
                GameCell c = currentCell.nextCell(GameDirection.LEFT);
                IncreaseScore(c);
                if (c.currentGameObject.displayCharacter == ' ' || c.currentGameObject.displayCharacter == '.')
                {
                    Program.moveGameObject(this, direction);
                }
            }
            else if (direction == GameDirection.RIGHT)
            {
                GameCell c = currentCell.nextCell(GameDirection.RIGHT);
                IncreaseScore(c);
                if (c.currentGameObject.displayCharacter == ' ' || c.currentGameObject.displayCharacter == '.')
                {
                    Program.moveGameObject(this, direction);
                }
            }
        }
    }
}
