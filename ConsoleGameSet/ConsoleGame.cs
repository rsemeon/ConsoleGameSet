using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    abstract class ConsoleGame
    {
        public string Name { get; set; }
        public string Description { get; set; }

        protected ConsoleBoard board;
        protected ConsoleGameMove move;
        protected ConsolePlayer player;
        protected ConsolePlayer computer;
        protected string[] playPieces;
        protected string currentTurn;
        protected string winner;
        

        public ConsoleGame(string name) : this(name, "")
        {
        }

        public ConsoleGame(string name, string description) {
            Name = name;
            Description = description;
        }

        abstract public void NextMove();

        abstract public void Draw();

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
