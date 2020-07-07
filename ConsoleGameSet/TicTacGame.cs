using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    class TicTacGame : ConsoleGame
    {
        enum PlayOptions
        {
            O,
            X
        }

        TicTacBoard board = new TicTacBoard();
        PlayOptions currentTurn = PlayOptions.X; // X always starts
        TicTacPlayer player = new TicTacUser();
        String winner;

        public TicTacGame(string name, string description) : base(name, description)
        {
        }

        public override void ResetGame()
        {

        }

        public override void NextMove()
        {

        }

        public override void Draw()
        {
            board.DrawBoard();
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
        public string GetWinner()
        {
            if (String.IsNullOrWhiteSpace(winner))
            {
                winner = board.CheckStatus();
            }

            return winner;
        }
    }
}
