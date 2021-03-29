using System;
using System.Collections.Generic;
using ScoreCombination.Domain.Entities;

namespace ScoreCombination.Domain.Interfaces.Services
{
    public interface IServiceRecord : IServiceBase<ScoreCombinationRecord>
    {
        IEnumerable<ScoreCombinationRecord> GetCallHistory(DateTime initialDate, DateTime finalDate);
        ScoreCombinationResult GetCombination(ScoreCombinationRequest request);
    }
}