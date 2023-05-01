using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.BL
{
    class Enemy1
    {
        public Enemy1(int X, int Y, string direction, int health)
        {
            this.X = X;
            this.Y = Y;
            this.direction = direction;
            this.health = health;
        }
        public int X;
        public int Y;
        public string direction;
        public int health;
    }
}
