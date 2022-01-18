using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Auth
{
    [Authorize(Roles = "SuperAdmin")]
    public class RolesController : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public List<IdentityRole> IdentityRole { get; set; }
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public void OnGet()
        {
            var roles = _roleManager.Roles.ToList();
            IdentityRole = roles;
        }
        public async Task<IActionResult> OnPost(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToPage("../auth/Roles");
        }
    }
}
