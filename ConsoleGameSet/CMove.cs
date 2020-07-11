using System;
using System.Text;

namespace ConsoleGameSet
{
    class CMove
    {
        public int x;
        public int y;

        public CMove()
        {
            x = int.MinValue;
            y = int.MinValue;
        }

        public void SetCoordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int[] GetCoordinate()
        {
            return new int[] { x, y };
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public void Set(int value)
        {
            x = value;
        }
        public int Get()
        {
            return GetX();
        }
    }
}
