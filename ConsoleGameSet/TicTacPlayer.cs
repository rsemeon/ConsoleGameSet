using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleGameSet
{
    class TicTacPlayer : ConsolePlayer
    {
        public override int[] GetMove(ConsoleBoard board)
        {
            bool validInput;
            string[] userInputSplit;
            string[] userChoiceString;
            int[] move = { 0, 0 };

            do
            {
                validInput = true;

                Console.Write("\n".PadRight(15) + "Enter a grid position (e.g. x,y ) : ");
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
                            move[0] = int.Parse(userChoiceString[0]);
                            move[1] = int.Parse(userChoiceString[1]);
                        }
                        catch
                        {
                            validInput = false;
                        }
                    }

                    if (move[0] < 1 || move[0] > board.getBoardWidth()) { validInput = false; }
                    if (move[1] < 1 || move[1] > board.getBoardHeight()) { validInput = false; }

                    move[0]--;
                    move[1]--;

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
