using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Auth

{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class UserRolesController : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        [BindProperty]
        public ManageUserRolesViewModel IdentityUserRoles { get; set; }
        [BindProperty]
        public IdentityUser IdentityUser { get; set; }
        public UserRolesController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
                                   RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task OnGet(string Id)
        {
            IdentityUserRoles = new();
            IdentityUser = new();
            IdentityUserRoles.UserRoles = new List<UserRolesViewModel>();
            var user = await _userManager.FindByIdAsync(Id);
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                IdentityUserRoles.UserRoles.Add(userRolesViewModel);
            }
            IdentityUserRoles.UserId = Id;
            IdentityUser.UserName = user.UserName;
        }

        public async Task<IActionResult> OnPost(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            result = await _userManager.AddToRolesAsync(user, IdentityUserRoles.UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
            var currentUser = await _userManager.GetUserAsync(User);
            await _signInManager.RefreshSignInAsync(currentUser);

            return RedirectToPage("./User", new { Id });
        }
    }
}

