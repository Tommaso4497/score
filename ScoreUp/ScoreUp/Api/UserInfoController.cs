using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreUp.Core;
using ScoreUp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScoreUp
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IRepository<UserInfo> _dataPlayer;
        public IEnumerable<UserInfo> UserInfos { get; set; }
        public UserInfo UserInfo { get; set; }

        public UserInfoController(IRepository<UserInfo> data_Player)
        {
            _dataPlayer = data_Player;
        }

        // GET: api/UserInfoes
        [HttpGet]
        public IEnumerable<UserInfo> GetUserInfos()
        {
            return _dataPlayer.GetAllUserId();
        }

        // GET: api/UserInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfo(int id)
        {
            var userInfo = await _dataPlayer.GetByIdAsync(id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return userInfo;
        }

        // PUT: api/UserInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo(int id, UserInfo userInfo)
        {
            if (id != userInfo.Id)
            {
                return BadRequest();
            }

            _dataPlayer.Update(userInfo);

            try
            {
                await _dataPlayer.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (UserInfo.Id != (id))
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

        // POST: api/UserInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUserInfo(UserInfo userInfo)
        {
            await _dataPlayer.AddAsync(userInfo);
            await _dataPlayer.SaveAsync();

            return CreatedAtAction("GetUserInfo", new { id = userInfo.Id }, userInfo);
        }

        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo(int id)
        {
            var userInfo = await _dataPlayer.GetByIdAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            _dataPlayer.Remove(userInfo);
            await _dataPlayer.SaveAsync();

            return NoContent();
        }


    }
}
