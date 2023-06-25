using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GL
{
    public class GameObject
    {
        public char displayCharacter;
        public GameCell currentCell;
        public GameObjectType currentObject;

        public GameObject(GameObjectType type, char displayCharacter)
        {
            this.displayCharacter = displayCharacter;
            currentObject = type;
        }

        public GameObject()
        {
            displayCharacter = ' ';
            currentCell = null;
            currentObject = GameObjectType.NONE;
        }

        public static GameObjectType GetGameObjectType(string displayCharacter)
        {
            if (displayCharacter == "|" || displayCharacter == "%" || displayCharacter == "#")
            {
                return GameObjectType.WALL;
            }
            else if (displayCharacter == ".")
            {
                return GameObjectType.REWARD;
            }
            else if (displayCharacter == "P")
            {
                return GameObjectType.PLAYER;
            }
            else if (displayCharacter == "E")
            {
                return GameObjectType.ENEMY;
            }
            else if (displayCharacter == " ")
            {
                return GameObjectType.NONE;
            }
            return GameObjectType.NONE;
        }

    }
}
