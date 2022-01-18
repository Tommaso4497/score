using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScoreUp.Core;
using ScoreUp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ScoreUp.Core.Entities.EnumListOfGenre;

namespace ScoreUp.Pages.Game
{
    [Authorize(Roles = "SuperAdmin")]
    public class CreateEditGameModel : PageModel
    {
        private readonly IRepository<GameInfo> _datagame;
        private readonly IHtmlHelper _htmlHelper;
        [BindProperty]
        public GameInfo GameInfos { get; set; }
        public IEnumerable<SelectListItem> Genre { get; set; }
        public CreateEditGameModel(IRepository<GameInfo> repositorygame, IHtmlHelper htmlHelper)
        {
            _datagame = repositorygame;
            _htmlHelper = htmlHelper;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Genre = _htmlHelper.GetEnumSelectList<ListOfGenre>();
            if (id.HasValue)
            {
                GameInfos = await _datagame.GetByIdAsync(id.Value);
            }
            else
            {
                GameInfos = new GameInfo();
            }
            if (GameInfos == null)
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
            Genre = _htmlHelper.GetEnumSelectList<ListOfGenre>();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (GameInfos.Id > 0)
            {
                _datagame.Update(GameInfos);
            }
            else
            {
                await _datagame.AddAsync(GameInfos);
            }
            await _datagame.SaveAsync();
            TempData["Message"] = "Gioco Salvato!";
            return RedirectToPage("DetailVideogame", new { id = GameInfos.Id });
        }
    }
}
