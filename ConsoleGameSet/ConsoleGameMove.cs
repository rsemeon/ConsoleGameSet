using System;
using System.Text;

namespace ConsoleGameSet
{
    class ConsoleGameMove
    {
        int[] move;

        public ConsoleGameMove(): this(1)
        {
        }

        public ConsoleGameMove(int num)
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
