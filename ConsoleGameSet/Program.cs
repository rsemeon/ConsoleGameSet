using System;

namespace ConsoleGameSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool validInput;

            while (true) // Main program loop
            {
                validInput = false;

                MainMenu mainMenu = new MainMenu("Main menu");
                CGame currentGame = null;
                bool keepPlaying = true;
                ConsoleKey userChoice = ConsoleKey.Escape;

                while (!validInput) // main menu loop
                {
                    DrawHeader(mainMenu.Name);
                    mainMenu.Draw();
                    userChoice = mainMenu.GetInput();

                    switch (userChoice)
                    {
                        case ConsoleKey.D1:
                            currentGame = new TicTacGame("Tic-Tac-Toe");
                            validInput = true;
                            break;

                        case ConsoleKey.D2:
                            currentGame = new Connect4Game("Connect 4");
                            validInput = true;
                            break;

                        case ConsoleKey.Q:
                            Environment.Exit(0);
                            break;

                        default:
                            break;
                    }
                }  

                do
                {
                    // Initialize game
                    DrawHeader(currentGame.Name);
                    currentGame.ResetGame();
                    currentGame.Draw();

                    // Start game loop
                    while (!currentGame.IsGameOver())
                    {
                        currentGame.NextMove();

                        DrawHeader(currentGame.Name);

                        currentGame.Draw();
                    }


                    // Ask user to restart game
                    if (!GetYesOrNo("Do you want to restart the game ? (y / n) :  "))
                    {
                        keepPlaying = false;
                    }

                } while (keepPlaying); // game loop

            }
        }

        private static void DrawHeader(String subtitle)
        {
            Console.Clear();

            int screenWidth = 80;
            string screenTitle = "Console Game Set";
            int spaceLeft;
            int spaceRight;

            // Console.WriteLine(".........1.........2.........3.........4.........5.........6.........7.........8.........9.........0");
            // Console.WriteLine("┌".PadRight(screenWidth - 1, '─') + "┐");
            Console.WriteLine("┌" + Fill('─', screenWidth - 2) + "┐");
            Console.WriteLine("│" + Fill(' ', screenWidth - 2) + "│");

            spaceLeft = (int)((screenWidth - screenTitle.Length) / 2) - 1;
            spaceRight = screenWidth - screenTitle.Length - spaceLeft - 2;
            Console.WriteLine("│" + Fill(' ', spaceLeft) + screenTitle + Fill(' ', spaceRight) + "│");

            Console.WriteLine("│" + Fill(' ', screenWidth - 2) + "│");
            Console.WriteLine("└────────╥" + Fill('─', screenWidth - 21) + "╥─────────┘");

            spaceLeft = (int)((screenWidth - subtitle.Length) / 2) - 10;
            spaceRight = screenWidth - subtitle.Length - spaceLeft - 21;
            Console.WriteLine("         ║" + Fill(' ', spaceLeft) + subtitle + Fill(' ', spaceRight) + "║");

            Console.WriteLine("         ╚" + Fill('═', screenWidth - 21) + "╝");
        }

        private static string Fill(char chr, int whiteSpace)
        {
            return new String(chr, whiteSpace);
        }

        /// <summary>This method asks user to select Y or N key press
        ///     returns true for Y and false for N</summary>
        private static bool GetYesOrNo(String message)
        {
            ConsoleKey userkeyPress;

            do
            {
                int margin = 15;
                Console.Write("".PadRight(margin) + message);
                Console.CursorLeft -= 1; // wipe any previous invalid key press

                userkeyPress = Console.ReadKey(false).Key; // get user key press and display on screen

                Console.SetCursorPosition(0, Console.CursorTop); // change to start of row to use same row to re-ask question

            } while (userkeyPress != ConsoleKey.Y && userkeyPress != ConsoleKey.N); // only continue if key is Y or N

            return userkeyPress == ConsoleKey.Y ? true : false;
        }
    }
}
