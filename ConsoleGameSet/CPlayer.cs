using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    abstract class CPlayer
    {
        public string tag;

        public abstract CMove GetMove(CBoard board);
    }

}
