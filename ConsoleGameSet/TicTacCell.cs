using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    class TicTacCell : CBoardCell
    {
        public TicTacCell(string[] boardPieces) : base(boardPieces)
        {
        }

        public override void WriteValue()
        {
            Console.Write(this.Get());
        }
    }
}
