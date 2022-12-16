using System;

namespace Lb1.GameImplementation
{
    public class Game
    {
        private static int _gameNumber=100000;
        private GameAccount Player1 { get; }
        private GameAccount Player2 { get; }
        
        public Game(GameAccount player1, GameAccount player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        
        public void SimulationGame(int count=1)
        {
            var rnd = new Random();
            for (var i = 0; i < count; i++)
            {
                var randomNumber = rnd.Next(1, 11);
                if (randomNumber <= 5)
                {
                    Player1.WinGame(randomNumber, _gameNumber, Player2);
                    Player2.LoseGame(randomNumber,_gameNumber, Player1);
                    _gameNumber++;
                }
                else
                {
                    Player1.LoseGame(randomNumber, _gameNumber, Player2);
                    Player2.WinGame(randomNumber, _gameNumber, Player1);
                    _gameNumber++;
                }
            }
        }    
    }
}