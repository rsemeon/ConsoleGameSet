using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    class TicTacBoard : CBoard
    {
        public TicTacBoard() : base(width: 3, height: 3, winCount: 3, playPieces:new string[] {"X","O"})
        {
            BoardCells = new TicTacCell[boardSize.Width, boardSize.Height];

            for (int x = 0; x < boardSize.Width; x++)
            {
                for (int y = 0; y < boardSize.Height; y++)
                {
                    BoardCells[x, y] = new TicTacCell(boardPieces);
                }
            }
        }

        override public void Draw()
        {
            int StartX = 32;
            int StartY = Console.CursorTop + 2;
            string row1, row2, row3;

            // Draw horizontal cell numbers
            Console.CursorTop = StartY - 1;
            Console.CursorLeft = StartX + 2;
            for (int i = 1; i <= boardSize.Width; i++)
            {
                Console.Write("{0}   ", i);
            }

            // Draw vertical cell numbers  
            Console.CursorTop = StartY + 1;
            Console.CursorLeft = 0;
            string tab = new String(' ', StartX - 2);

            for (int i = 1; i <= boardSize.Height; i++)
            {

                Console.Write("{0}{1}\n\n", tab, i);
            }


            // Draw Board
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            for (int y = 0; y < boardSize.Height; y++)
            {
                for (int x = 0; x < boardSize.Width; x++)
                {
                    Console.CursorTop = StartY - y + (y * 3);

                    // Draw top line of Cell
                    if (y == 0)
                    {
                        if (x == 0) { row1 = "    │"; }
                        else if (x == boardSize.Width - 1) { row1 = "│    "; }
                        else { row1 = "│   │"; }

                    }
                    else
                    {
                        if (x == 0) { row1 = "────┼"; }
                        else if (x == boardSize.Width - 1) { row1 = "┼────"; }
                        else { row1 = "┼───┼"; }
                    }

                    Console.CursorLeft = StartX - x + (x * 5);
                    Console.WriteLine(row1);

                    // Draw middle line of Cell
                    string CellValue = BoardCells[x, y].Get();
                    if (String.IsNullOrWhiteSpace(CellValue)) { CellValue = " "; }

                    if (x == 0) { row2 = "  " + CellValue + " │"; }
                    else if (x == boardSize.Width - 1) { row2 = "│ " + CellValue + "  "; }
                    else { row2 = "│ " + CellValue + " │"; }

                    Console.CursorLeft = StartX - x + (x * 5);
                    Console.WriteLine(row2);

                    // Draw bottom line of Cell
                    if (y == boardSize.Height - 1)
                    {
                        if (x == 0) { row3 = "    │"; }
                        else if (x == boardSize.Width - 1) { row3 = "│    "; }
                        else { row3 = "│   │"; }

                        Console.CursorLeft = StartX - x + (x * 5);
                        Console.WriteLine(row3);
                    }

                }
            }
            Console.ResetColor();
        }

    }
}
