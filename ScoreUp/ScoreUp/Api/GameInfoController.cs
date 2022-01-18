using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreUp.Core;
using ScoreUp.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreUp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameInfoController : ControllerBase
    {
        private readonly ScoreUpDbContext _context;

        public GameInfoController(ScoreUpDbContext context)
        {
            _context = context;
        }

        // GET: api/GameInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameInfo>>> GetGameInfo()
        {
            return await _context.GameInfo.ToListAsync();
        }

        // GET: api/GameInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameInfo>> GetGameInfo(int id)
        {
            var gameInfo = await _context.GameInfo.FindAsync(id);

            if (gameInfo == null)
            {
                return NotFound();
            }

            return gameInfo;
        }

        // PUT: api/GameInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameInfo(int id, GameInfo gameInfo)
        {
            if (id != gameInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GameInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameInfo>> PostGameInfo(GameInfo gameInfo)
        {
            _context.GameInfo.Add(gameInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameInfo", new { id = gameInfo.Id }, gameInfo);
        }

        // DELETE: api/GameInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameInfo(int id)
        {
            var gameInfo = await _context.GameInfo.FindAsync(id);
            if (gameInfo == null)
            {
                return NotFound();
            }

            _context.GameInfo.Remove(gameInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameInfoExists(int id)
        {
            return _context.GameInfo.Any(e => e.Id == id);
        }
    }
}
