using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    abstract class ConsolePlayer
    {
        public string tag;

        public abstract ConsoleGameMove GetMove(ConsoleBoard board);
    }

}
