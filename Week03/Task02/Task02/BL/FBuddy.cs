using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.BL
{
    class FBuddy
    {
        public FBuddy(int X, int Y, int health, string printDirection, bool isJump, int jumpTick)
        {
            this.X = X;
            this.Y =Y;
            this.health = health;
            this.printDirection = printDirection;
            this.isJump = isJump;
            this.jumpTick = jumpTick;

        }
        public int X;
        public int Y;
        public int health;
        public string printDirection;
        public bool isJump = false;
        public int jumpTick = 0;
    }
    class Bullet
    {
        public Bullet(int X, int Y, char BulletDirection)
        {
            this.X = X;
            this.Y = Y;
            this.BulletDirection = BulletDirection;
        }
        public int X;
        public int Y;
        public char BulletDirection;
        
    }
}
