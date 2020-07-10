using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    abstract class ConsoleBoardCell
    {
        string[] cellValues;
        protected string value;

        protected ConsoleBoardCell(string[] boardPieces)
        {
            cellValues = boardPieces;
            value = cellValues[0];
        }

        public void Set(string newValue)
        {
            if (Array.Exists(cellValues, e => e == newValue))
            {
                value = newValue;
            }
        }

        public string Get()
        {
            return value;
        }

        public bool IsSet()
        {
            if (value == cellValues[0])
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        abstract public void WriteValue();
    }
}
