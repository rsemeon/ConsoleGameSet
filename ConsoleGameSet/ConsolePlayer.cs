using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    abstract class ConsolePlayer
    {
        public string tag;

        public override string ToString()
        {
            return tag;
        }

        abstract public int[] GetMove(ConsoleBoard board);


    }
}
