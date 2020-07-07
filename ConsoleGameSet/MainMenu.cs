using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace ConsoleGameSet
{
    class MainMenu
    {
        int leftMargin = 32;
        public string Name { get; set; }

        public MainMenu(string name)
        {
            Name = name;
        }

        public void Draw()
        {
            Console.WriteLine("\n");

            Console.WriteLine(new String(' ', leftMargin) + "[1] Tic-Tac-Toe" + "\n");

            Console.WriteLine(new String(' ', leftMargin) + "[2] Connect 4" + "\n");

            Console.WriteLine(new String(' ', leftMargin) + "[Q] Quit" + "\n");
        }

        public ConsoleKey GetInput()
        {
            ConsoleKey userkeyPress;

            Console.WriteLine("\n");

            while (true)
            {
                Console.CursorLeft = leftMargin - 10;

                Console.Write("Select an option :  ");
                Console.CursorLeft -= 1; // to wipe any previous invalid key press on refresh

                userkeyPress = Console.ReadKey(false).Key;

                return userkeyPress;
            }
        }
    }
}

