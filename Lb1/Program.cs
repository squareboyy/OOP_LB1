using System;

namespace Lb1
{
     class Game
    {
        public static void Main(string[] args)
        {
             Console.WriteLine("\t\t-------------------------DuoGame--------------------------------------------------");
             var nikita = new GameAccount("Nikita", 2);
             nikita.DuoGame("Nikita", 2, "Vlad", 5, 5);
            
             Console.WriteLine("\t\t----------------------------------------------------------------------------------");
             var oleg = new GameAccount("Oleg", 2);
             oleg.LoseGame(5, "Roma");
             oleg.WinGame(5, "Roma");
             oleg.WinGame(15, "Roma");
             Console.WriteLine(oleg.GetStats());
 
             Console.WriteLine("\t\t----------------------------------------------------------------------------------");
             
             var vlad = new GameAccount("Vlad", 3);
             vlad.WinGame(13, "Anton");
             vlad.LoseGame(2, "Anton");
             vlad.WinGame(15, "Anton");
             Console.WriteLine(vlad.GetStats());
        }
    }
}