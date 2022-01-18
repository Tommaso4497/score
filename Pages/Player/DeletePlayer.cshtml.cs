using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Core;

using ScoreUp.Data;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Player
{
    [Authorize(Roles = "SuperAdmin")]
    public class DeletePlayerModel : PageModel
    {
        private readonly IRepository<UserInfo> _dataplayer;
        [TempData]
        public string Message { get; set; }
        public UserInfo UserInfo { get; set; }
        public DeletePlayerModel(IRepository<UserInfo> repositoryplayer)
        {
            _dataplayer = repositoryplayer;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            UserInfo = await _dataplayer.GetByIdAsync(id);

            if (UserInfo == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            UserInfo = await _dataplayer.GetByIdAsync(id);
            _dataplayer.Remove(UserInfo);
            await _dataplayer.SaveAsync();
            if (UserInfo == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"Il giocatore {UserInfo.PlayerName} è stato eliminato";
            return RedirectToPage("ListPlayer");
        }
    }
}
