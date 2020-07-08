using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    interface IConsoleBoardCell
    {
        public void Set(string value);

        public string Get();

        public bool IsSet();
    }
}
