using System;

namespace ClassStore
{
    internal static class ConsoleUI
    {
        public static void Header(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ╔══════════════════════════════════════════════╗");
            Console.WriteLine("  ║             MINI INVENTORY STORE             ║");
            Console.WriteLine("  ╚══════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n  ✦ " + title + " ✦\n");
            Console.ResetColor();
        }

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  ✓ " + message);
            Console.ResetColor();
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  ! " + message);
            Console.ResetColor();
        }

        public static void Pause()
        {
            Console.WriteLine("\n  Press any key to continue...");
            Console.ReadKey();
        }
    }
}
