using System;
using System.Collections.Generic;

namespace Lb1
{
    public class GameAccount
    {
        private List<GameInfo> _gameInfoList = new List<GameInfo>();
        public string UserName { get;}
        public int GamesCount {get; set;}
        public int InitialRating { get;}
        public int CurrentRating
        {
            get 
            {
                int rating = InitialRating;
                foreach (var item in _gameInfoList)
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
            InitialRating = rating;
        }

        public void WinGame(int rating, GameAccount opponetName)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating for which they are playing must be positive");
            }
          
            var win = new GameInfo(rating, "Win", opponetName.UserName);
            var lose = new GameInfo(-rating, "Lose", UserName, -1);
            _gameInfoList.Add(win);
            opponetName._gameInfoList.Add(lose);
            GamesCount++;
            opponetName.GamesCount = GamesCount;
        } 

        public void LoseGame(int rating, GameAccount opponetName)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating for which they are playing must be positive");
            }
            var lose = new GameInfo(-rating,"Lose", opponetName.UserName);
            var win = new GameInfo(rating, "Win", UserName, -1);
            _gameInfoList.Add(lose);
            opponetName._gameInfoList.Add(win);
            GamesCount++;
            opponetName.GamesCount = GamesCount;
        }
        
        public void RandomGame(GameAccount opponent, int countGames)
        {
            Random rnd = new Random();
            for (int i = 0; i < countGames; i++)
            {
                int randomNumber = rnd.Next(1, 11);
                if (randomNumber < 5)
                {
                    WinGame(randomNumber, opponent);
                }
                else
                {
                    LoseGame(randomNumber, opponent);
                }
            }
            Console.WriteLine(GetStats());
        }

        public string GetStats()
        {
            var report = new System.Text.StringBuilder();

            report.Append("\tStatistics of the player:");
            report.Append($"\t{UserName}"+"\t\t\t|\n");
            
            report.AppendLine("\tInitial rating\tPlayed games\tCurrent rating"+"\t\t|"); 
            report.AppendLine($"\t{InitialRating}\t\t{GamesCount}\t\t{CurrentRating}"+"\t\t\t|");
            
            report.AppendLine("\t\t\tHistory of games"+"\t\t\t|");
            report.AppendLine("\tId game\t\tOpponent\tResult\t\tPoints"+"\t|");
            foreach (var item in _gameInfoList)
            {
                report.AppendLine($"\t{item.Id}\t\t{item.Name}\t\t{item.Result}\t\t{Math.Abs(item.Rating)}"+"\t|");
            }

            return report.ToString();
        }
    }
}