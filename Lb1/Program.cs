using System;

namespace Lb1
{
    static class Game
    {
        public static void Main(string[] args)
        {
            var nik = new GameAccount("square", 15);
            var vlad = new GameAccount("karkush", 10);
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tСтатистика пiсля методу RandomGame");
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            
            nik.RandomGame(vlad,5);
            Console.WriteLine(vlad.GetStats());
            
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tСтатистика гравцiв пiсля ще декiлькох iмiтацiй iгор");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            
            vlad.LoseGame(15, nik);
            nik.WinGame(5, vlad);
            nik.LoseGame(3, vlad);
            vlad.WinGame(7, nik);
            Console.WriteLine(nik.GetStats());
            Console.WriteLine(vlad.GetStats());
        }
    }
}