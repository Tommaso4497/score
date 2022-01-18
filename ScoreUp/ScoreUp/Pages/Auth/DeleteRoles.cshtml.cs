using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Models;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Auth
{
    [Authorize(Roles = "SuperAdmin")]
    public class DeleteRoles : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        [TempData]
        public string Message { get; set; }
        public PermissionViewModel RolesIdentity { get; set; }
        public DeleteRoles(RoleManager<IdentityRole> dataroles)
        {
            _roleManager = dataroles;
        }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            RolesIdentity = new();
            var roles = await _roleManager.FindByIdAsync(id);
            RolesIdentity.RoleId = roles.Name;
            if (roles == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            if (role == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"Il ruolo {role} è stato eliminato";
            return RedirectToPage("Roles");
        }
    }
}
