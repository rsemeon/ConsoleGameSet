using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    class Connect4Game : ConsoleGame
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

        override public void NextMove()
        {
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
                  
                    int columnCount = board.ColumnCount(move.Get());
                    if (columnCount < board.GetHeight())
                    {
                        board.SetCellContent(move.Get(), board.GetHeight()-columnCount-1, GetCurrentTurn());
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Entered column is full!");
                    }
                } while (!validInput);

                // flip turn
                NextTurn(playPieces[0], playPieces[1]);
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
