using System;

namespace ConsoleGameSet
{
    class TicTacGame : CGame
    {
        public TicTacGame(string name) : this(name,"")
        {
        }

        public TicTacGame(string name, string description) : base(name, description)
        {
            board = new TicTacBoard();
            player = new TicTacPlayer();
            computer = new TicTacRandomMove();

            playPieces = board.GetPlayPieces();
            ResetGame();
        }

        override public bool ValidateMove(CMove move, int margin = 15)
        {
            if (board.IsCellFree(move.x, move.y))
            {
                board.SetCellContent(move.x, move.y, GetCurrentTurn());
                return true;
            }
            else
            {
                string invalidInputMsg = "Cell already taken!";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("".PadLeft(margin) + invalidInputMsg.PadRight(Console.WindowWidth - margin - invalidInputMsg.Length));
                Console.CursorTop -= 1;
                Console.ResetColor();
                return false;
            }
        }

        public override void Draw()
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

            Console.WriteLine("\n\n");

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
