using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    class Connect4Cell : ConsoleBoardCell
    {
        public Connect4Cell(string[] boardPieces) : base(boardPieces)
        {
        }

        public override void WriteValue()
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            char chr = '\u24FF'; //'\u2588'; // '\u25A0';
            switch (value)
            {
                   case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                default:
                    chr = Char.MinValue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            Console.Write(chr);
            Console.ForegroundColor = currentColor;
        }
    }
}
