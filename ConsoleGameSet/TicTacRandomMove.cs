using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    class TicTacRandomMove : ConsolePlayer
    {

        public override int[] GetMove(ConsoleBoard board)
        {
            int[] move = { 0, 0 };

            // Pause for 1 sec if Computer's turn
            System.Threading.Thread.Sleep(500);

            // Choose Computer's move at random

            Random random = new Random();

            move[0] = random.Next(0, board.getBoardWidth());
            move[1] = random.Next(0, board.getBoardHeight());

            return move;
        }
    }
}
