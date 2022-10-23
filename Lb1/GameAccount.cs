using System;
using System.Collections.Generic;
using System.Linq;

namespace Lb1
{
    public class GameAccount
    {
        private List<GameInfo> GameInfoList = new List<GameInfo>();
        
        private static int gameNumber=100000;
        public string UserName { get; set;}
        public int GamesCount {get; set;}
        public int CurrentRating
        {
            get
            {
                int rating = 0;
                foreach (var item in GameInfoList)
                {
                    rating += item.Rating;
                    if (rating < 1)
                    {
                        rating = 1;
                    }
                }
                return rating;
            }
        }
        public GameAccount(string name, int rating)
        {
            UserName = name;
            var initialRating = new GameInfo(0, rating, null, null);
            GameInfoList.Add(initialRating);
        }

        public void WinGame(int rating, string opponetName)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating for which they are playing must be positive");
            }
            var win = new GameInfo(++gameNumber, rating, "Win", opponetName);
            GameInfoList.Add(win);
            GamesCount++;
        }

        public void LoseGame(int rating, string opponetName)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating for which they are playing must be positive");
            }
            var lose = new GameInfo(++gameNumber, -rating,"Lose", opponetName);
            GameInfoList.Add(lose);
            GamesCount++;
        }

        public void DuoGame(string player, int playerRating, string opponent, int opponentRating, int countGames)
        {
            Random rnd = new Random();
            int [] x = new int[countGames];
            int [] random = new int[countGames];
            for (int i = 0; i < countGames; i++)
            {
                int randomNumber = rnd.Next(1, 11);
                if (randomNumber < 5)
                {
                    x[i] = 0;
                    random[i] = randomNumber;
                    WinGame(randomNumber,opponent); 
                }
                else
                {
                    x[i] = 1;
                    random[i] = randomNumber;
                    LoseGame(randomNumber, opponent);
                }
            }
            UserName = player;
            Console.WriteLine(GetStats());
            
            GameInfoList.Clear();
            GamesCount = 0;
            gameNumber = 100000;
            
            UserName = opponent;
            var initialDuoRating2 = new GameInfo(0, opponentRating, null, null);
            GameInfoList.Add(initialDuoRating2);
            
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == 0)
                {
                    LoseGame(random[i], player); 
                }
                else
                {
                    WinGame(random[i], player);  
                }
            }
            Console.WriteLine(GetStats());
        }

        public string GetStats()
        {
            var report = new System.Text.StringBuilder();
            int initialRating = 0;
            
              foreach (var item in GameInfoList)
              {
                  initialRating = item.Rating;
                  if (initialRating <= 0)
                  {
                      initialRating = 1;
                  }
                  break;
              }
              
            report.AppendLine("\tName\t\tInitial rating\t\tPlayed games");
            report.AppendLine($"\t{UserName}\t\t\t{initialRating}\t\t{GamesCount}\n");
            report.AppendLine("\tId game\t\tOpponent\tResult\t\tPoints\t\tRating after the match");
            
            foreach (var item in GameInfoList.Skip(1)) 
            {
                initialRating += item.Rating;
                if (initialRating < 1)
                {
                    initialRating = 1;
                }
                report.AppendLine($"\t{item.Id}\t\t{item.Name}\t\t{item.Result}\t\t{Math.Abs(item.Rating)}\t\t\t{initialRating}");
            }
            return report.ToString();
        }
    }
}