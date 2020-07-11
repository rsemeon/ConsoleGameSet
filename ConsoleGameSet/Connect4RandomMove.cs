using System;

namespace ConsoleGameSet
{
    class Connect4RandomMove : CPlayer
    {
        public override CMove GetMove(CBoard board)
        {
            CMove move = new CMove();

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