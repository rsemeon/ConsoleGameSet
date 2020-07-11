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

            do
            {
                validInput = true;
                string invalidInputMsg = "Invalid input try again!";

                Console.Write("".PadRight(margin) + "Enter a column to play : ");
                string userInput = Console.ReadLine();

                if (userInput == "quit" || userInput == "q" || userInput == "exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    if (String.IsNullOrWhiteSpace(userInput)) { throw new ArgumentOutOfRangeException("userInput", "user input is null or whitespace"); }

                    moveValue = int.Parse(userInput);
                    if (moveValue < 1 || moveValue > board.GetWidth()) { throw new ArgumentOutOfRangeException("moveValue", "Selected move is out of bounds"); }
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
                    Console.WriteLine(invalidInputMsg);
                }

            } while (!validInput);

            return move;
        }

    }
}