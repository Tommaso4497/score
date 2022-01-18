using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScoreUp.Core;
using ScoreUp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Score
{
    [Authorize(Roles = "SuperAdmin")]
    public class CreateEditScore : PageModel
    {
        private readonly IRepository<ScoreInfo> _datascore;
        private readonly IRepository<GameInfo> _datagame;
        private readonly ScoreUpDbContext _context;
        [BindProperty]
        public ScoreInfo ScoreInfo { get; set; }
        public IEnumerable<GameInfo> GameList { get; set; }
        public CreateEditScore(IRepository<ScoreInfo> repositoryscore, ScoreUpDbContext contex, IRepository<GameInfo> repositorygame)
        {
            _datascore = repositoryscore;
            _context = contex;
            _datagame = repositorygame;
        }
        public IActionResult OnGet()
        {
            ViewData["Gioco"] = new SelectList(_context.GameInfo, "Id", "Title");
            ViewData["Giocatore"] = new SelectList(_context.UserInfo, "Id", "PlayerName");
            GameList = _datagame.GetAllGameId();
            ScoreInfo = new ScoreInfo();
            if (ScoreInfo == null || GameList == null)
            {
                return RedirectToPage("../NotFound");
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
            if (ScoreInfo.Id > 0)
            {
                _datascore.Update(ScoreInfo);
            }
            else
            {
                await _datascore.AddAsync(ScoreInfo);
            }
            await _datascore.SaveAsync();
            TempData["Message"] = "Punteggio Salvato!";
            return RedirectToPage("ListScore", new { id = ScoreInfo.Id });
        }
    }
}



