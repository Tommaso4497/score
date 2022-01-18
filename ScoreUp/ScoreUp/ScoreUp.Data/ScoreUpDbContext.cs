using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScoreUp.Core;

namespace ScoreUp.Data
{
    public class ScoreUpDbContext : IdentityDbContext
    {
        public ScoreUpDbContext(DbContextOptions<ScoreUpDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<GameInfo> GameInfo { get; set; }
        public DbSet<ScoreInfo> Score { get; set; }

    }
}
