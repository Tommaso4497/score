

using ScoreUp.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreUp.Core
{
    public class ScoreInfo : EntityBase
    {
        public int Score_Point { get; set; }
        [ForeignKey("GameInfo")]
        public int GameRefId { get; set; }
        public GameInfo GameInfo { get; set; }
        [ForeignKey("UserInfo")]
        public int UserRefId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
