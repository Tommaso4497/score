using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ScoreUp.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreUp.Data
{
    #region DbOpertaions
    public class SqlRepo<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ScoreUpDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public ScoreUpDbContext DbContext => _dbContext;

        public DbSet<T> DbSet => _dbSet;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int PageIndex { get; set; } = 1;

        public SqlRepo(ScoreUpDbContext dbContext)

        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

        }
        public async Task AddAsync(T item)
        {

            await _dbSet.AddAsync(item);

        }
        public void Remove(T item)
        {
            var entity = _dbContext.Attach(item);
            entity.State = EntityState.Modified;
            _dbContext.Remove(item);

        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T item)
        {
            var entity = _dbContext.Attach(item);
            entity.State = EntityState.Modified;

        }



        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        #endregion

        public IEnumerable<T> GetAllUserId()
        {
            var query = _dbContext.UserInfo
                        .Select(t => t);

            return (IEnumerable<T>)query;
        }
        public IEnumerable<T> GetAllGameId()
        {
            var query = _dbContext.GameInfo
                        .Select(t => t);

            return (IEnumerable<T>)query;
        }

        public IEnumerable<T> GetScore()
        {
            var query = _dbContext.Score
                .Include(s => s.GameInfo)
                .Include(s => s.UserInfo);

            return (IEnumerable<T>)query;
        }
        public IQueryable<T> SearchUser(string name)
        {
            var query = _dbContext.UserInfo
                        .Where(t => t.PlayerName.StartsWith(name) || string.IsNullOrEmpty(name))
                        .OrderBy(t => t.PlayerName)
                        // .ToPagedList(PageIndex,5)
                        .Select(t => t);

            return (IQueryable<T>)query;
        }
        public IQueryable<T> SearchGame(string GameName)
        {
            var query = _dbContext.GameInfo
                        .Where(t => t.Title.StartsWith(GameName) || string.IsNullOrEmpty(GameName))
                        .OrderBy(t => t.Title)
                        .Select(t => t);
            return (IQueryable<T>)query;
        }
        public IQueryable<T> SearchScoreByUser(string score)
        {
            var query = _dbContext.Score
                        .Include(s => s.GameInfo)
                        .Include(s => s.UserInfo)
                        .Where(t => t.UserInfo.PlayerName.StartsWith(score) || string.IsNullOrEmpty(score))
                        .OrderBy(t => t.UserInfo.PlayerName)
                        .Select(t => t);

            return (IQueryable<T>)query;
        }

        public IQueryable<T> GetBestScores()
        {
            var query = (from t in _dbContext.Score
                         group t by new { t.GameRefId } into g
                         select new
                         {
                             PunteggioMassimo = g.Max(s => s.Score_Point),
                             GameRefIdSub = g.Key.GameRefId
                         }
                           into a
                         select a);

            var query2 = (from a in _dbContext.UserInfo
                          from e in query
                          join f in _dbContext.Score on new
                          {
                              IdUser = a.Id,
                              Punteggio_Massimo = e.PunteggioMassimo,
                              GameRef = e.GameRefIdSub
                          }
                          equals new
                          {
                              IdUser = f.UserRefId,
                              Punteggio_Massimo = f.Score_Point,
                              GameRef = f.GameRefId
                          }
                          group new
                          {
                              e,
                              f,
                              a
                          }
                          by new
                          {
                              a.PlayerName,
                              a.PlayerSurname,
                              f.UserRefId
                          }
                         into e
                          select new RecordInfo
                          {
                              Nome = e.Key.PlayerName,
                              Cognome = e.Key.PlayerSurname,
                              RecordPartite = e.Select(e => e.f.UserRefId).Count()
                          }
                         into e
                          orderby e.RecordPartite descending
                          select e);

            return (IQueryable<T>)query2;
        }
    }
}
