
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Core;
using ScoreUp.Data;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Player
{
    [Authorize(Roles = "SuperAdmin")]
    public class CreateEditPlayerModel : PageModel
    {
        private readonly IRepository<UserInfo> _dataplayer;
        [BindProperty]
        public UserInfo UserInfos { get; set; }
        [TempData]
        public string Message { get; set; }
        public CreateEditPlayerModel(IRepository<UserInfo> repositoryplayer)
        {
            _dataplayer = repositoryplayer;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                UserInfos = await _dataplayer.GetByIdAsync(id.Value);
            }
            else
            {
                UserInfos = new UserInfo();
            }
            if (UserInfos == null)
            {
                return RedirectToPage("NotFound");
            }
            else
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (UserInfos.Id > 0)
            {
                _dataplayer.Update(UserInfos);
            }
            else
            {
                await _dataplayer.AddAsync(UserInfos);
            }
            await _dataplayer.SaveAsync();
            TempData["Message"] = "Utente Salvato!";
            return RedirectToPage("./DetailPlayer", new { id = UserInfos.Id });
        }
    }
}



