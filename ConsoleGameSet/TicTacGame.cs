using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    class TicTacGame : ConsoleGame
    {
        public TicTacGame(string name) : base(name)
        {
        }

        public TicTacGame(string name, string description) : base(name, description)
        {
        }

        enum PlayOptions
        {
            O,
            X
        }

        TicTacBoard board = new TicTacBoard();
        PlayOptions currentTurn = PlayOptions.X; // X always starts
        TicTacPlayer player = new TicTacPlayer();
        TicTacRandomMove computer = new TicTacRandomMove();

        public override void ResetGame()
        {
            winner = ""; // reset winner
            board.ResetBoard();
            player.tag = CoinToss().ToString();
            computer.tag = player.tag == "X" ? "O" : "X";
        }

        public override void NextMove()
        {
            if (!IsGameOver())
            {
                int[] move;
                bool validInput;

                // Get next players choice
                do
                {
                    validInput = false;

                    if (player.tag == GetCurrentTurn())
                    {
                        // Player's move
                        move = player.GetMove(board);
                    }
                    else
                    {
                        //Computer's move
                        move = computer.GetMove(board);

                    }

                    if (board.IsCellFree(move[0], move[1]))
                    {
                        board.SetCellContent(move[0], move[1], GetCurrentTurn());
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Cell already taken");
                    }

                } while (!validInput);

                // flip turn
                NextTurn();
            }
        }

        public override void Draw()
        {
            board.Draw();

            DrawFooter();
        }

        public override bool IsGameOver()
        {
            if (GetWinner() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void NextTurn()
        {
            currentTurn = currentTurn == PlayOptions.O ? PlayOptions.X : PlayOptions.O;
        }

        public string GetCurrentTurn()
        {
            return currentTurn.ToString();
        }

        public string GetWinner()
        {
            if (String.IsNullOrWhiteSpace(winner))
            {
                winner = board.CheckStatus();
            }

            return winner;
        }

        public bool IsDraw()
        {
            if (GetWinner() == "draw")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPlayerWinner()
        {
            if (GetWinner() == player.tag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPlayersTurn()
        {
            if (player.tag == GetCurrentTurn())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetPlayerTag()
        {
            return player.tag;
        }

        private static PlayOptions CoinToss()
        {
            Random random = new Random();

            return random.Next(0, 2) < 1 ? PlayOptions.O : PlayOptions.X;
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
