using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ConsoleGameSet
{
    abstract class CBoard
    {

        protected CBoardCell[,] BoardCells;
        public int WinCount { get; set; }

        protected Size boardSize = new Size();

        protected string[] boardPieces;

        public CBoard(int width, int height, int winCount, string[] playPieces)
        {
            boardSize.Width = width;
            boardSize.Height = height;
            WinCount = winCount;

            int piecesCount = playPieces.Length + 1;

            boardPieces = new string[] { "" }.Union(playPieces).ToArray();
        }


        public string[] GetPlayPieces()
        {
            return new string[] { boardPieces[1], boardPieces[2] };
        }

        abstract public void Draw();
        
        public void ResetBoard()
        {
            for (int x = 0; x < boardSize.Width; x++)
            {
                for (int y = 0; y < boardSize.Height; y++)
                {
                    BoardCells[x, y].Set(boardPieces[0]);
                }
            }
        }

        public string CheckStatus()
        {
            for(int i=1; i < boardPieces.Length; i++)
            {
                if (CheckWin(boardPieces[i]))
                {
                    return boardPieces[i];
                }
            }

            if (IsBoardFull())
            {
                return "draw";
            }
            else
            {
                return null;
            }
        }

        private bool IsBoardFull()
        {
            for (int x = 0; x < boardSize.Width; x++)
            {
                for (int y = 0; y < boardSize.Height; y++)
                {
                    if (String.IsNullOrWhiteSpace(BoardCells[x, y].Get()))
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
             if (String.IsNullOrWhiteSpace(BoardCells[x, y].Get()))
            {
                BoardCells[x, y].Set(content);
            }
        }

        public string GetCellContent(int x, int y)
        {
            return BoardCells[x, y].Get();
        }

        public int GetWidth()
        {
            return boardSize.Width;
        }

        public int GetHeight()
        {
            return boardSize.Height;
        }

        public int ColumnCount(int col)
        {
            int count = 0;

            for (int y = boardSize.Height - 1; y >= 0; y--)
            {
                if (BoardCells[col, y].IsSet())
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        public bool CheckWin(string currentPlayer)
        {
            if (currentPlayer == "null")
            {
                return false;
            }

            int count;

            // Check vertical positions
            for (int y = 0; y < boardSize.Height; y++)
            {
                for (int x = 0; x < boardSize.Width; x++)
                {
                    // Check horizontal positions
                    if (x < boardSize.Width - WinCount + 1)
                    {
                        count = 0;
                        for (int i = 0; i < WinCount; i++)
                        {
                            if (BoardCells[x + i, y].Get() == currentPlayer) { count++; }
                        }

                        if (count == WinCount) { return true; }
                    }

                    // Check vertical positions
                    if (y < boardSize.Height - WinCount + 1)
                    {
                        count = 0;
                        for (int i = 0; i < WinCount; i++)
                        {
                            if (BoardCells[x, y + i].Get() == currentPlayer) { count++; }
                        }
                        if (count == WinCount) { return true; }
                    }

                    // Check diagonal positions (top to left)
                    if (y < boardSize.Height - WinCount + 1 && x < boardSize.Width - WinCount + 1)
                    {
                        count = 0;
                        for (int i = 0; i < WinCount; i++)
                        {
                            if (BoardCells[x + i, y + i].Get() == currentPlayer) { count++; }
                        }
                        if (count == WinCount) { return true; }
                    }

                    // Check diagonal positions (top to left)
                    if (y < boardSize.Height - WinCount + 1 && x >= WinCount - 1 && x < boardSize.Width)
                    {
                        count = 0;
                        for (int i = 0; i < WinCount; i++)
                        {
                            if (BoardCells[x - i, y + i].Get() == currentPlayer) { count++; }
                        }
                        if (count == WinCount) { return true; }
                    }
                }
            }
            return false;
        }

    }
}
