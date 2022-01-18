using System.Collections.Generic;

namespace ScoreUp.Costant
{
public static class Permissions
{
    public static List<string> GeneratePermissionsForModule()
    {
        return new List<string>()
        {
            $"Permissions.Create",
            $"Permissions.View",
            $"Permissions.Edit",
            $"Permissions.Delete",
        };
    }

    public static class Operations
    {
        public const string View = "Permissions.View";
        public const string Create = "Permissions.Create";
        public const string Edit = "Permissions.Edit";
        public const string Delete = "Permissions.Delete";
    }
}
}