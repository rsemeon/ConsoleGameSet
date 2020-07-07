using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{

    enum CellValues
    {
        X,
        O,
        NULL
    }

    class ConsoleBoardCell
    {
        public CellValues value;

        public ConsoleBoardCell()
        {
            value = CellValues.NULL;
        }

        public void Set(string newStatus)
        {
            switch (newStatus)
            {
                case "X":
                    value = CellValues.X;
                    break;
                case "O":
                    value = CellValues.O;
                    break;
                default:
                    value = CellValues.NULL;
                    break;
            }
        }

        public string Get()
        {
            switch (value)
            {
                case CellValues.X:
                    return "X";

                case CellValues.O:
                    return "O";

                default:
                    return "";
            }
        }

        public bool IsSet()
        {
            if(value == CellValues.NULL)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
