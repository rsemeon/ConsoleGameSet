using System;

namespace ConsoleGameSet
{
    class Connect4Board : ConsoleBoard
    {
        public Connect4Board() : base(width: 7, height: 6, winCount: 4, playPieces: new string[] { "Red", "Blue" })
        { 
            BoardCells = new Connect4Cell[boardSize.Width, boardSize.Height];

            for (int x = 0; x < boardSize.Width; x++)
            {
                for (int y = 0; y < boardSize.Height; y++)
                {
                    BoardCells[x, y] = new Connect4Cell(boardPieces);
                }
            }
        }

        override public void Draw()
        {
            int StartX = 25;
            int StartY = Console.CursorTop + 3;

            // Draw column numbers
            Console.CursorTop = StartY - 2;
            Console.CursorLeft = StartX + 2;
            for (int i = 1; i <= boardSize.Width; i++)
            {
                Console.Write("{0}   ", i);
            }

            // Draw Board
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            for (int y = 0; y < boardSize.Height; y++)
            {
                for (int x = 0; x < boardSize.Width; x++)
                {
                    Console.CursorTop = StartY - y + (y * 3);
                    Console.CursorLeft = StartX - x + (x * 5);

                    // Draw top line of Cell
                    if (y == 0)
                    {
                        Console.WriteLine("│   │");
                    }
                    else
                    {
                        Console.WriteLine("┼───┼");
                    }

                    // Draw middle line of Cell
                    Console.CursorLeft = StartX - x + (x * 5);
                    Console.Write("│ ");
                    BoardCells[x, y].WriteValue();
                    Console.WriteLine(" │");

                    // Draw bottom line of Cell
                    if (y == boardSize.Height - 1)
                    {
                        Console.CursorLeft = StartX - x + (x * 5);
                        Console.WriteLine("┴───┴");
                    }

                }
            }
            Console.ResetColor();
        }
    }
}