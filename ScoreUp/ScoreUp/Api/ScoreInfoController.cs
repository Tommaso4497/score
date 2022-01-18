using Microsoft.AspNetCore.Mvc;
using ScoreUp.Core;
using ScoreUp.Core.Entities;
using ScoreUp.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreUp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreInfoController : ControllerBase
    {
        private readonly IRepository<RecordInfo> _dataScoreRecord;
        private readonly IRepository<ScoreInfo> _dataScore;
        public IEnumerable<ScoreInfo> Scores { get; set; }
        public IEnumerable<RecordInfo> ScoresRecord { get; set; }

        public ScoreInfoController(IRepository<ScoreInfo> rep_Score, IRepository<RecordInfo> rep_Record)
        {

            _dataScore = rep_Score;
            _dataScoreRecord = rep_Record;
        }

        // GET: api/ScoreInfo
        //[HttpGet]
        //public IEnumerable<ScoreInfo> GetScores()
        //{
        //    return _dataScore.GetScore().ToList();
        //}

        [HttpGet("Best")]
        public IEnumerable<RecordInfo> GetBestScores()
        {
            return _dataScoreRecord.GetBestScores().ToList();
        }


        // GET: api/ScoreInfo/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<ScoreInfo>> GetScoreInfoAsync(int id)
        {
            var scoreInfo = await _dataScore.GetByIdAsync(id);

            if (scoreInfo == null)
            {
                return (IEnumerable<ScoreInfo>)NotFound();
            }

            return (IEnumerable<ScoreInfo>)scoreInfo;
        }

        // DELETE: api/ScoreInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScoreInfo(int id)
        {
            var scoreInfo = await _dataScore.GetByIdAsync(id);
            if (scoreInfo == null)
            {
                return NotFound();
            }

            _dataScore.Remove(scoreInfo);
            await _dataScore.SaveAsync();

            return NoContent();
        }
    }
}
