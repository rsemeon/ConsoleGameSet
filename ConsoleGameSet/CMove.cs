using System;
using System.Text;

namespace ConsoleGameSet
{
    class CMove
    {
        int[] move;

        public CMove(): this(1)
        {
        }

        public CMove(int num)
        {
            move = new int[num];
        }

        public void SetCoordinate(int x, int y)
        {
            move[0] = x;
            move[1] = y;
        }

        public int[] GetCoordinate()
        {
            return move;
        }

        public int GetX()
        {
            return move[0];
        }

        public int GetY()
        {
            return move[1];
        }

        public int Get()
        {
            return move[0];
        }

        public void Set(int value)
        {
            move[0] = value;
        }
    }
}
