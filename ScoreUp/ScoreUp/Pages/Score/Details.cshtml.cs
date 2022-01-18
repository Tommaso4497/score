using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Core;
using ScoreUp.Data;


namespace ScoreUp.Pages.Score


{
    public class DetailScoreModel : PageModel
    {
        private readonly IRepository<ScoreInfo> _score_data;

        [TempData]
        public string Message { get; set; }


        public ScoreInfo ScoreInfo { get; set; }


        public DetailScoreModel(IRepository<ScoreInfo> score_rep)
        {
            _score_data = score_rep;

        }
        public IActionResult OnGet(int id)
        {

            ScoreInfo = _score_data.GetById(id);



            if (ScoreInfo == null)
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


