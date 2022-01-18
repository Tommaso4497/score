using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreUp.Core;
using ScoreUp.Core.Entities;
using ScoreUp.Data;
using System.Collections.Generic;

namespace ScoreUp.Pages
{
    [AllowAnonymous]
    public class ListModel : PageModel
    {
        private readonly IRepository<UserInfo> _dataPlayer;
        private readonly IRepository<GameInfo> _dataGame;
        private readonly IRepository<ScoreInfo> _dataScore;
        private readonly IRepository<RecordInfo> _dataScoreRecord;
        public IEnumerable<UserInfo> UserInfos { get; set; }
        public IEnumerable<GameInfo> GameInfos { get; set; }
        public IEnumerable<ScoreInfo> Scores { get; set; }
        public IEnumerable<RecordInfo> ScoreRecordMan { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        public ListModel(IRepository<UserInfo> repositoryplayer, IRepository<GameInfo> repositorygame,
                         IRepository<ScoreInfo> repositoryscore, IRepository<RecordInfo> repositoryrecord)
        {
            _dataGame = repositorygame;
            _dataPlayer = repositoryplayer;
            _dataScore = repositoryscore;
            _dataScoreRecord = repositoryrecord;
        }
        public void OnGet()
        {
            UserInfos = _dataPlayer.SearchUser(SearchTerms);
            GameInfos = _dataGame.SearchGame(SearchTerms);
            Scores = _dataScore.SearchScoreByUser(SearchTerms);
            ScoreRecordMan = _dataScoreRecord.GetBestScores();
        }
    }
}
