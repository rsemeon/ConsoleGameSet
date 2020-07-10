using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleGameSet
{
    class TicTacPlayer : ConsolePlayer
    {
        public override ConsoleGameMove GetMove(ConsoleBoard board)
        {
            bool validInput;
            string[] userInputSplit;
            string[] userChoiceString;
            ConsoleGameMove move = new ConsoleGameMove(2);
            int x = 0, y = 0;
            int margin = 15;

            do
            {
                validInput = true;

                Console.Write("\n".PadRight(margin) + "Enter a grid position (e.g. x,y ) : ");
                string userInput = Console.ReadLine();

                if (userInput == "quit" || userInput == "q" || userInput == "exit")
                {
                    Environment.Exit(0);
                }

                if (!String.IsNullOrWhiteSpace(userInput))
                {
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

                    x--;
                    y--;

                    move.SetCoordinate(x, y);

                }

                if (validInput)
                {
                    return move;
                }
                else
                {
                    Console.WriteLine("Invalid input try again!");
                }

            } while (!validInput);

            return move;
        }
    }
}
