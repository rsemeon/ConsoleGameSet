using System;

namespace ConsoleGameSet
{
    class Connect4Game : CGame
    {
        public Connect4Game(string name) : this(name, "")
        {
        }

        public Connect4Game(string name, string description) : base(name, description)
        {
            board = new Connect4Board();
            player = new Connect4Player();
            computer = new Connect4RandomMove();

            playPieces = board.GetPlayPieces();
            ResetGame();
        }

        override public bool ValidateMove(CMove move, int margin = 15)
        {
            int topFreecell = board.GetHeight() - board.ColumnCount(move.x) - 1;
            if (topFreecell >= 0)
            {
                board.SetCellContent(move.x, topFreecell, GetCurrentTurn());
                return true;
            }
            else
            {
                string invalidInputMsg = "Entered column is full!";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("".PadLeft(margin) + invalidInputMsg.PadRight(Console.WindowWidth - margin - invalidInputMsg.Length));
                Console.CursorTop -= 1;
                Console.ResetColor();
                return false;
            }
        }

        override public void Draw()
        {
            board.Draw();

            DrawFooter();
        }

        private void DrawFooter()
        {
            int leftMargin = 14;

            string footerMessage = GetGameEndMessage();

            if (String.IsNullOrWhiteSpace(footerMessage))
            {
                if (IsPlayersTurn())
                {
                    footerMessage = "Player's turn";
                }
                else
                {
                    footerMessage = "Computer's turn";
                }

                footerMessage += $" ({GetCurrentTurn()})";
            }

            Console.WriteLine("".PadRight(leftMargin) + "────────────────────────────────────────────────────");

            Console.Write("".PadRight(leftMargin));

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            footerMessage = $"  {footerMessage}";
            Console.WriteLine(footerMessage.PadRight(52, ' '));
            Console.ResetColor();

            Console.WriteLine("".PadRight(leftMargin) + "────────────────────────────────────────────────────\n");

        }

        private string GetGameEndMessage()
        {
            string footerMessage = "";

            if (IsGameOver())
            {
                if (IsDraw())
                {
                    footerMessage = "Game is a DRAW";
                }
                else
                {
                    footerMessage = $"Winner is {GetWinner()}";
                    if (IsPlayerWinner())
                    {
                        footerMessage += " - Player wins!";
                    }
                    else
                    {
                        footerMessage += " - Computer wins!";
                    }
                }
            }

            return footerMessage;
        }

    }
}
