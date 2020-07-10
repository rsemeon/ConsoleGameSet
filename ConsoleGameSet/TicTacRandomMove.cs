using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    class TicTacRandomMove : ConsolePlayer
    {

        public override ConsoleGameMove GetMove(ConsoleBoard board)
        {
            ConsoleGameMove move = new ConsoleGameMove(2);

            // Pause for 1 sec if Computer's turn
            System.Threading.Thread.Sleep(500);

            // Choose Computer's move at random

            Random random = new Random();

            int x = random.Next(0, board.GetWidth());
            int y = random.Next(0, board.GetHeight());

            move.SetCoordinate(x, y);

            return move;
        }
    }
}
