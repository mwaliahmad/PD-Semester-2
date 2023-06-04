using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01.BL
{
    public class Cell
    {
        public Cell(char Value, int X, int Y)
        {
            this.Value = Value;
            this.X = X;
            this.Y = Y;
        }

        public char Value;
        public int X;
        public int Y;

        public char GetChar()
        {
            return Value;
        }
        public void SetChar(char Value)
        {
            this.Value = Value;
        }
        public int GetX()
        {
            return X;
        }
        public int GetY()
        {
            return Y;
        }
        public bool PacmanPresent()
        {
            if(Value == 'P')
            {
                return true;
            }
            return false;
        }
        public bool GhostPresent(char ghostchar)
        {
            if (Value == ghostchar)
            {
                return true;
            }
            return false;
        }
    }
}
