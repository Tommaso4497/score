
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Core;
using ScoreUp.Data;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Player
{
    [AllowAnonymous]
    public class DetailPlayerModel : PageModel
    {
        private readonly IRepository<UserInfo> _dataplayer;
        [TempData]
        public string Message { get; set; }
        public UserInfo UserInfo { get; set; }
        public DetailPlayerModel(IRepository<UserInfo> repositoryplayer)
        {
            _dataplayer = repositoryplayer;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            UserInfo = await _dataplayer.GetByIdAsync(id);
            if (UserInfo == null)
            {
                return RedirectToPage("NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
