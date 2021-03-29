using System;
using System.Collections.Generic;
using System.Linq;
using ScoreCombination.Domain.Entities;
using ScoreCombination.Domain.Interfaces.Repositories;
using ScoreCombination.Infrastructure.Data.Database;

namespace ScoreCombination.Infrastructure.Data.Repositories
{
    public class RepositoryRecord : RepositoryBase<ScoreCombinationRecord>, IRepositoryRecord
    {
        private readonly ScoreCombinationDbContext _context;

        public RepositoryRecord(ScoreCombinationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ScoreCombinationRecord> GetCallHistory(DateTime initialDate, DateTime finalDate)
        {
            var allRecords = _context.Set<ScoreCombinationRecord>().ToList();

            return allRecords.Where(record =>
                record.Date >= initialDate
                && record.Date <= finalDate).ToList();
        }
    }
}
