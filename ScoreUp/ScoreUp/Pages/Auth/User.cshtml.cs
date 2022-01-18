using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Auth
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class UsersController : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IEnumerable<IdentityUser> IdentityUser { get; set; }
        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            IdentityUser = _userManager.Users.Where(a => a.Id != currentUser.Id);

        }
    }
}


