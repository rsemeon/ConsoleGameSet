using System;

namespace ConsoleGameSet
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawHeader("subtitle");
        }

        private static void DrawHeader(String subtitle)
        {
            int screenWidth = 80;
            string screenTitle = "Console Game Set";
            int spaceLeft;
            int spaceRight;

            // Console.WriteLine(".........1.........2.........3.........4.........5.........6.........7.........8.........9.........0");
            // Console.WriteLine("┌".PadRight(screenWidth - 1, '─') + "┐");
            Console.WriteLine("┌" + Fill('─', screenWidth - 2) + "┐");
            Console.WriteLine("│" + Fill(' ', screenWidth - 2) + "│");

            spaceLeft = (int)((screenWidth - screenTitle.Length) / 2) - 1;
            spaceRight = screenWidth - screenTitle.Length - spaceLeft - 2;
            Console.WriteLine("│" + Fill(' ', spaceLeft) + screenTitle + Fill(' ', spaceRight) + "│");

            Console.WriteLine("│" + Fill(' ', screenWidth - 2) + "│");
            Console.WriteLine("└────────╥" + Fill('─', screenWidth - 21) + "╥─────────┘");

            spaceLeft = (int)((screenWidth - subtitle.Length) / 2) - 10;
            spaceRight = screenWidth - subtitle.Length - spaceLeft - 21;
            Console.WriteLine("         ║" + Fill(' ', spaceLeft) + subtitle + Fill(' ', spaceRight) + "║");

            Console.WriteLine("         ╚" + Fill('═', screenWidth - 21) + "╝");
        }

        private static string Fill(char chr, int whiteSpace)
        {
            return new String(chr, whiteSpace);
        }
    }
}
