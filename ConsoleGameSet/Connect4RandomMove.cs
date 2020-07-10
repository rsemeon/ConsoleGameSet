using System;

namespace ConsoleGameSet
{
    class Connect4RandomMove : ConsolePlayer
    {
        public override ConsoleGameMove GetMove(ConsoleBoard board)
        {
            ConsoleGameMove move = new ConsoleGameMove();

            // Pause for 1 sec if Computer's turn
            System.Threading.Thread.Sleep(500);

            // Choose Computer's move at random

            Random random = new Random();

            int value = random.Next(0, board.GetWidth());

            move.Set(value);

            return move;
        }
    }
}