using Microsoft.EntityFrameworkCore;
using ScoreCombination.Core.Domain;

namespace ScoreCombination.Core.Database
{
    public class ScoreCombinationDbContext : DbContext
    {
        public ScoreCombinationDbContext(DbContextOptions<ScoreCombinationDbContext> options) : base(options) {}

        public DbSet<ScoreCombinationRecord> Record { get; set; }
        
    }
}