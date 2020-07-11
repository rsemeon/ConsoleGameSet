using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    abstract class CGame
    {
        public string Name { get; set; }
        public string Description { get; set; }

        protected CBoard board;
        protected CMove move;
        protected CPlayer player;
        protected CPlayer computer;
        protected string[] playPieces;
        protected string currentTurn;
        protected string winner;
        

        public CGame(string name) : this(name, "")
        {
        }

        public CGame(string name, string description) {
            Name = name;
            Description = description;
        }

        abstract public void Draw();

        abstract public bool ValidateMove(CMove move, int margin);

        public void NextMove()
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

                    validInput = ValidateMove(move, margin);

                } while (!validInput);

                // flip turn
                NextTurn(playPieces[0], playPieces[1]);
            }
        }

        public void ResetGame()
        {
            winner = ""; // reset winner
            board.ResetBoard();

            player.tag = CoinToss(playPieces[0], playPieces[1]);
            computer.tag = player.tag == playPieces[0] ? playPieces[1] : playPieces[0];
            currentTurn = playPieces[0];
        }

        protected string CoinToss(string piece1, string piece2)
        {
            Random random = new Random();

            return random.Next(0, 2) < 1 ? piece1 : piece2;
        }

        public void NextTurn(string piece1, string piece2)
        {
            currentTurn = currentTurn == piece1 ? piece2 : piece1;
        }

        public bool IsGameOver()
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

    }
}
