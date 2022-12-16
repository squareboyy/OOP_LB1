using System;
using System.Collections.Generic;

namespace Lb1.GameImplementation
{
    public class GameAccount
    {
        private readonly List<GameInfo> _gameInfoList = new List<GameInfo>();
        private string UserName {get;}
        private int GamesCount {get; set;}
        private int InitialRating {get;}

        private int CurrentRating
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

        public void WinGame(int rating, int id, GameAccount opponetName)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating for which they are playing must be positive");
            }
            var win = new GameInfo(rating, "Win", opponetName.UserName, id);
            _gameInfoList.Add(win);
            GamesCount++;
        } 

        public void LoseGame(int rating, int id, GameAccount opponetName)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating for which they are playing must be positive");
            }
            var lose = new GameInfo(-rating,"Lose", opponetName.UserName, id);
            _gameInfoList.Add(lose);
            GamesCount++;
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