using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    abstract class CPlayer
    {
        public string tag;

        protected int cursorTop = 0;
        public abstract CMove GetMove(CBoard board);

        protected string GetUserInput(int top, int left, string message)
        {
            Console.CursorTop = top;
            Console.Write("".PadRight(left) + message.PadRight(Console.WindowWidth - left - message.Length));
            Console.CursorLeft = left + message.Length + 1;
            return Console.ReadLine();
        }
    }

}
