using System.ComponentModel.DataAnnotations;

namespace ScoreUp.Core.Entities
{
    public class EnumListOfGenre
    {
        public enum ListOfGenre
        {
            [Display(Name = "Non cononosco il genere")]
            No_Genre,
            [Display(Name = "Action")]
            Action,
            [Display(Name = "RPG")]
            RPG,
            [Display(Name = "Avventura")]
            Adventure,
            [Display(Name = "Di Corsa")]
            Racing,
            [Display(Name = "Arcade")]
            Arcade,
            [Display(Name = "SandBox")]
            Sandbox,
            [Display(Name = "Battle Royale")]
            Battle_Royale,
            [Display(Name = "FPS")]
            FPS,
            [Display(Name = "TPS")]
            TPS

        }
    }
}
