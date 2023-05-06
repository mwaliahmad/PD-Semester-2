using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.BL
{
    public class Angle
    {
        public Angle(int degree , float minutes, char direction)
        {
            this.degree = degree;
            this.minutes = minutes;
            this.direction = direction;
        }
        public int degree;
        public float minutes;
        public char direction;

        public string GetAngle()
        {
            string angle = degree.ToString() + "\u00b0" + minutes.ToString() + "'" + direction.ToString();
            return angle;    
        }
    }
}
