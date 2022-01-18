using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Models;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Auth
{
    [Authorize(Roles = "SuperAdmin")]
    public class DeleteUserModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        [TempData]
        public string Message { get; set; }
        public ManageUserRolesViewModel IdentityUser { get; set; }
        public IdentityUser Identity { get; set; }
        public DeleteUserModel(UserManager<IdentityUser> datauser)
        {
            _userManager = datauser;
        }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            IdentityUser = new();
            Identity = new();
            var users = await _userManager.FindByIdAsync(id);
            Identity.UserName = users.UserName;
            IdentityUser.UserId = users.Id;
            if (users == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            if (user == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"Il ruolo {user} è stato eliminato";
            return RedirectToPage("User");
        }
    }
}


