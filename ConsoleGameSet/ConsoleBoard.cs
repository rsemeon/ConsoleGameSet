using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Text;

namespace ConsoleGameSet
{
    abstract class ConsoleBoard
    {

        protected Size boardSize = new Size();

        protected ConsoleBoardCell[,] ConsoleBoardCells;

        public int WinCount { get; set; }

        public ConsoleBoard(int width, int height, int winCount)
        {
            boardSize.Width = width;
            boardSize.Height = height;

            ConsoleBoardCells = new ConsoleBoardCell[boardSize.Width, boardSize.Height];

            for (int x = 0; x < boardSize.Width; x++)
            {
                for (int y = 0; y < boardSize.Height; y++)
                {
                    ConsoleBoardCells[x, y] = new ConsoleBoardCell();
                }
            }

            WinCount = winCount;

        }

        abstract public void DrawBoard();
        
        abstract public bool CheckWin(string currentPlayer);

        public void ResetBoard()
        {
            for (int x = 0; x < boardSize.Width; x++)
            {
                for (int y = 0; y < boardSize.Height; y++)
                {
                    ConsoleBoardCells[x, y].Set(null);
                }
            }
        }

        public string CheckStatus()
        {
            if (CheckWin("O"))
            {
                return "O";
            }
            else if (CheckWin("X"))
            {
                return "X";
            }
            else if (IsBoardFull())
            {
                return "draw";
            }

            return null;
        }

        private bool IsBoardFull()
        {
            for (int x = 0; x < boardSize.Width; x++)
            {
                for (int y = 0; y < boardSize.Height; y++)
                {
                    if (String.IsNullOrWhiteSpace(ConsoleBoardCells[x, y].Get()))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsCellFree(int x, int y)
        {
            if (GetCellContent(x, y) == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetCellContent(int x, int y, string content)
        {
            if (String.IsNullOrWhiteSpace(ConsoleBoardCells[x, y].Get()))
            {
                ConsoleBoardCells[x, y].Set(content);
            }
        }

        public string GetCellContent(int x, int y)
        {
            return ConsoleBoardCells[x, y].Get();
        }

        public int getBoardWidth()
        {
            return boardSize.Width;
        }

        public int getBoardHeight()
        {
            return boardSize.Height;
        }

    }
}
