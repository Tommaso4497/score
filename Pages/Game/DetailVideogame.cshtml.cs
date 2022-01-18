
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Core;
using ScoreUp.Data;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Game
{
    [AllowAnonymous]
    public class DetailGameModel : PageModel
    {
        private readonly IRepository<GameInfo> _datagame;
        [TempData]
        public string Message { get; set; }
        public GameInfo GameInfo { get; set; }
        public DetailGameModel(IRepository<GameInfo> repositorygame)
        {
            _datagame = repositorygame;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            GameInfo = await _datagame.GetByIdAsync(id);
            if (GameInfo == null)
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
