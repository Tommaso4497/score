using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Core;
using ScoreUp.Data;
using System.Threading.Tasks;

namespace ScoreUp.Pages.Score
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class DeleteScoreModel : PageModel
    {
        private readonly IRepository<ScoreInfo> _datascore;
        public ScoreInfo ScoreInfo { get; set; }
        public DeleteScoreModel(IRepository<ScoreInfo> repositoryscore)
        {
            _datascore = repositoryscore;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            ScoreInfo = await _datascore.GetByIdAsync(id);

            if (ScoreInfo == null)
            {
                return RedirectToPage("../NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            ScoreInfo = await _datascore.GetByIdAsync(id);
            _datascore.Remove(ScoreInfo);
            await _datascore.SaveAsync();
            if (ScoreInfo == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"L'Elemento stato eliminato";
            return RedirectToPage("ListScore");
        }
    }
}
