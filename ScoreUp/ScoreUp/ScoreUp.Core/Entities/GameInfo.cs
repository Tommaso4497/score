using ScoreUp.Core.Entities;
using static ScoreUp.Core.Entities.EnumListOfGenre;

namespace ScoreUp.Core
{
    public class GameInfo : EntityBase
    {

        public string Title { get; set; }
        public ListOfGenre Genre { get; set; }




    }
}


