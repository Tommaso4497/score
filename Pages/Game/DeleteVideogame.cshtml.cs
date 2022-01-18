using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Core;
using ScoreUp.Data;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Game
{
    [Authorize(Roles = "SuperAdmin")]
    public class DeleteGameModel : PageModel
    {
        private readonly IRepository<GameInfo> _datagame;
        public GameInfo GameInfo { get; set; }
        [TempData]
        public string Message { get; set; }
        public DeleteGameModel(IRepository<GameInfo> repositorygame)
        {
            _datagame = repositorygame;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            GameInfo = await _datagame.GetByIdAsync(id);
            if (GameInfo == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            GameInfo = await _datagame.GetByIdAsync(id);
            _datagame.Remove(GameInfo);
            await _datagame.SaveAsync();
            if (GameInfo == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"Il gioco {GameInfo.Title} è stato eliminato";
            return RedirectToPage("ListGame");
        }
    }
}
