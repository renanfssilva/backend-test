using System;
using System.Collections.Generic;
using ScoreCombination.Domain.Entities;

namespace ScoreCombination.Domain.Interfaces.Repositories
{
    public interface IRepositoryRecord : IRepositoryBase<ScoreCombinationRecord>
    {
        IEnumerable<ScoreCombinationRecord> GetCallHistory(DateTime initialDate, DateTime finalDate);
    }
}