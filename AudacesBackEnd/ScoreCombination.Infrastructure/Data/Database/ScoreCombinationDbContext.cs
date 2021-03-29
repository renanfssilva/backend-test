using Microsoft.EntityFrameworkCore;
using ScoreCombination.Domain.Entities;

namespace ScoreCombination.Infrastructure.Data.Database
{
    public class ScoreCombinationDbContext : DbContext
    {
        public ScoreCombinationDbContext(DbContextOptions<ScoreCombinationDbContext> options) : base(options) {}

        public DbSet<ScoreCombinationRecord> Record { get; set; }
    }
}