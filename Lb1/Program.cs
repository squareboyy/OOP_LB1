using System;
using Lb1.GameImplementation;

namespace Lb1
{
    internal static class Program 
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            
            var nik = new GameAccount("square", 15);
            var vlad = new GameAccount("karkush", 10);
            var roma = new GameAccount("zadr0t",5);
            
            var session1 = new Game(nik, vlad);
            var session2 = new Game(nik, roma);

            session1.SimulationGame(4);
            session1.SimulationGame();
            session2.SimulationGame();
      
            Console.WriteLine(nik.GetStats());
            Console.WriteLine(vlad.GetStats());
            Console.WriteLine(roma.GetStats());
        }
    }
}