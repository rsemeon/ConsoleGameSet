using System;

namespace ConsoleGameSet
{
    class Connect4Player : CPlayer
    {
        public override CMove GetMove(CBoard board)
        {
            bool validInput;
            int margin = 15;
            CMove move = new CMove();
            int moveValue;
            if (cursorTop == 0)
            {
                cursorTop = Console.CursorTop;
            }

            do
            {
                validInput = true;
                string invalidInputMsg = "Invalid input try again!";

                string userInput = GetUserInput(cursorTop, margin, "Enter a column to play :");

                try
                {
                    moveValue = int.Parse(userInput);

                    if (moveValue < 1 || moveValue > board.GetWidth()) {
                        throw new ArgumentOutOfRangeException("", $"Selected column {moveValue} is out of bounds (1 - {board.GetWidth()})");
                    }

                    move.Set(moveValue - 1);
                }
                catch(Exception e)
                {
                    invalidInputMsg = e.Message;
                    validInput = false;
                }

                if (validInput)
                {
                    return move;  //convert move to array index
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("".PadLeft(margin) + invalidInputMsg.PadRight(Console.WindowWidth - margin - invalidInputMsg.Length));
                    Console.ResetColor();
                }

            } while (!validInput);

            return move;
        }

    }
}