using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    class TicTacBoard : ConsoleBoard
    {
        public TicTacBoard() : base(width:3, height:3, winCount:3)
        {
        }

        override public void DrawBoard()
        {


            int StartX = 7;
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
                    string CellValue = ConsoleBoardCells[x, y].Get();
                    if (CellValue == "") { CellValue = " "; }

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

        override public bool CheckWin(string currentPlayer)
        {
            int count;
            int verticalCount;

            for (int y = 0; y < boardSize.Height; y++)
            {
                count = 0;
                verticalCount = 0;
                for (int x = 0; x < boardSize.Width; x++)
                {
                    // Check Horizontal positions
                    if (ConsoleBoardCells[x, y].Get() == currentPlayer)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }

                    // Check Vertical positions (flip x y)
                    if (ConsoleBoardCells[y, x].Get() == currentPlayer)
                    {
                        verticalCount++;
                    }
                    else
                    {
                        verticalCount = 0;
                    }
                }

                if (count >= WinCount || verticalCount >= WinCount)
                {
                    return true;
                }
            }


            // Check diagonal positions (top to left)
            for (int y = 0; y < boardSize.Height - 2; y++)
            {

                for (int x = 0; x < boardSize.Width - 2; x++)
                {
                    count = 0;
                    if (ConsoleBoardCells[x, y].Get() == currentPlayer) { count++; }
                    if (ConsoleBoardCells[x + 1, y + 1].Get() == currentPlayer) { count++; }
                    if (ConsoleBoardCells[x + 2, y + 2].Get() == currentPlayer) { count++; }

                    if (count >= WinCount)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal positions (top to right)
            for (int y = 0; y < boardSize.Height - 2; y++)
            {
                for (int x = 2; x < boardSize.Width; x++)
                {
                    count = 0;
                    if (ConsoleBoardCells[x, y].Get() == currentPlayer) { count++; }
                    if (ConsoleBoardCells[x - 1, y + 1].Get() == currentPlayer) { count++; }
                    if (ConsoleBoardCells[x - 2, y + 2].Get() == currentPlayer) { count++; }
                    if (count >= WinCount)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
