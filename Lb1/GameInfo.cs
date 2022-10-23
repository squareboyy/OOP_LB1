
namespace Lb1
{
    public class GameInfo
    {
        public int Id {get;}
        public int Rating {get;}
        public string Result {get;}
        public string Name {get;}
        public GameInfo(int id, int rating, string result, string name)
        {
            this.Id = id;
            this.Rating = rating;
            this.Result = result;
            this.Name = name;
        }
    }
}