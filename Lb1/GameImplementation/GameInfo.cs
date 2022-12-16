
namespace Lb1.GameImplementation
{
    public class GameInfo
    {
        public int Id {get;}
        public int Rating {get;}
        public string Result {get;}
        public string Name {get;}
        public GameInfo(int rating, string result, string name, int id)
        {
            this.Rating = rating;
            this.Result = result;
            this.Name = name;
            this.Id = id;
        }
    }
}