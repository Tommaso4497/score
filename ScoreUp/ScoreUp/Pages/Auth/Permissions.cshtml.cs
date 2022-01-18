using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Helpers;
using ScoreUp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Auth
{
    [Authorize(Roles = "SuperAdmin")]
    public class PermissionsModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        [BindProperty(SupportsGet = true)]
        public List<RoleClaimsViewModel> RoleClaims { get; set; }

        [BindProperty]
        public PermissionViewModel Permissions { get; set; }
        public PermissionsModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task OnGetAsync(string id)
        {
            Permissions = new();
            RoleClaims = new();
            RoleClaims.GetPermissions(typeof(Costant.Permissions.Operations), id);
            var role = await _roleManager.FindByIdAsync(id);
            var claims = await _roleManager.GetClaimsAsync(role);
            var allClaimValues = RoleClaims.Select(a => a.Value).ToList();
            var roleClaimValues = claims.Select(a => a.Value).ToList();
            var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
            foreach (var permission in RoleClaims)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }

            Permissions.RoleClaims = RoleClaims;
            Permissions.RoleId = id;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var role = await _roleManager.FindByIdAsync(Permissions.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims = Permissions.RoleClaims.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                await _roleManager.AddPermissionClaim(role, claim.Value);
            }
            return RedirectToPage("./Roles", new { id = Permissions.RoleId });
        }
    }
}
