
namespace Lb1
{
    public class GameInfo
    {
        private static int _gameNumber=100000;
        public int Id {get;}
        public int Rating {get;}
        public string Result {get;}
        public string Name {get;}
        public GameInfo(int rating, string result, string name, int id = 0)
        {
            this.Rating = rating;
            this.Result = result;
            this.Name = name;
            this.Id = _gameNumber+id;
            _gameNumber=_gameNumber+1+id;
        }
    }
}