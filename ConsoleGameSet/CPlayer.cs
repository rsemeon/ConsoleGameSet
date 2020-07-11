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
            bool validInput = true;
            string userInput;
            do
            {

                Console.CursorTop = top;
                Console.Write("".PadRight(left) + message.PadRight(Console.WindowWidth - left - message.Length));
                Console.CursorLeft = left + message.Length + 1;

                userInput = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(userInput))
                {
                    validInput = false;
                }
                else if (userInput == "quit" || userInput == "q" || userInput == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    validInput = true;
                }

            } while (!validInput);

            return userInput;
        }
    }

}
