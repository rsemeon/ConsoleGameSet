using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleGameSet
{
    class TicTacPlayer : CPlayer
    {
        public override CMove GetMove(CBoard board)
        {
            bool validInput;
            string[] userInputSplit;
            string[] userChoiceString;
            CMove move = new CMove(2);
            int x = 0, y = 0;
            int margin = 15;

            if (cursorTop == 0)
            {
                cursorTop = Console.CursorTop;
            }

            do
            {
                validInput = true;

                string userInput = GetUserInput(cursorTop, margin, "Enter a grid position (e.g. x,y ) :");

                if (userInput.Contains(","))
                {
                    userChoiceString = userInput.Split(",");
                }
                else
                {
                    userInputSplit = Regex.Split(userInput, "");
                    userChoiceString = new string[] { userInputSplit[1], userInputSplit[2] };
                }

                if (userChoiceString.Length != 2)
                {
                    validInput = false;
                }
                else
                {
                    try
                    {
                        x = int.Parse(userChoiceString[0]);
                        y = int.Parse(userChoiceString[1]);
                    }
                    catch
                    {
                        validInput = false;
                    }
                }

                if (x < 1 || x > board.GetWidth()) { validInput = false; }
                if (y < 1 || y > board.GetHeight()) { validInput = false; }


                if (validInput)
                {
                    x--;
                    y--;
                    move.SetCoordinate(x, y);
                    return move;
                }
                else
                {
                    string invalidInputMsg = "Invalid input try again!";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("".PadLeft(margin) + invalidInputMsg.PadRight(Console.WindowWidth - margin - invalidInputMsg.Length));
                    Console.ResetColor();
                }

            } while (!validInput);

            return move;
        }
    }
}
