using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScoreUp.Costant
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule()
        {
            return new List<string>()
        {
            $"Create",
            $"View",
            $"Edit",
            $"Delete",
        };
        }

        public static class Operations
        {
            [Display(Name = "Visualizzazione")]
            public const string View = "View";
            [Display(Name = "Crea")]
            public const string Create = "Create";
            [Display(Name = "Modifica")]
            public const string Edit = "Edit";
            [Display(Name = "Elimina")]
            public const string Delete = "Delete";
        }
    }
}