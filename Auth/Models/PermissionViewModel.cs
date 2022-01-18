using System.Collections.Generic;

namespace ScoreUp.Models
{
    public class PermissionViewModel
    {
        public string RoleId { get; set; }
        public List<RoleClaimsViewModel> RoleClaims { get; set; }
    }
    public class RoleClaimsViewModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
  
    }
}
