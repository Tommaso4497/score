using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreUp.Data
{

    public interface IReadRepo<out T>
    {

        IEnumerable<T> GetAllGameId();
        IEnumerable<T> GetAllUserId();
        IEnumerable<T> GetScore();
        // Task<IQueryable<T>> SearchUserAsync(string name);
        IQueryable<T> SearchGame(string GameName);
        IQueryable<T> SearchUser(string name);
        IQueryable<T> SearchScoreByUser(string score);
        IQueryable<T> GetBestScores();
    }
    public interface IRepository<T> : IReadRepo<T> where T : IEntity
    {
        Task AddAsync(T item);
        void Remove(T item);
        Task<T> GetByIdAsync(int id);
        Task SaveAsync();
        void Update(T item);

    }

}
