using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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

        public override void NextMove()
        {
            int margin = 15;

            if (!IsGameOver())
            {
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

                    if (board.IsCellFree(move.GetX(), move.GetY()))
                    {
                        board.SetCellContent(move.GetX(), move.GetY(), GetCurrentTurn());
                        validInput = true;
                    }
                    else
                    {
                        string invalidInputMsg = "Cell already taken!";
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("".PadLeft(margin) + invalidInputMsg.PadRight(Console.WindowWidth - margin - invalidInputMsg.Length));
                        Console.CursorTop -= 1;
                        Console.ResetColor();
                    }

                } while (!validInput);

                // flip turn
                NextTurn(playPieces[0], playPieces[1]);
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
