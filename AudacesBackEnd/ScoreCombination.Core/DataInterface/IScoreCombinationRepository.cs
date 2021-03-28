using System;
using System.Collections.Generic;
using ScoreCombination.Core.Domain;

namespace ScoreCombination.Core.DataInterface
{
    public interface IScoreCombinationRepository
    {
        void Save(ScoreCombinationRecord scoreCombinationRecord);
        IEnumerable<ScoreCombinationRecord> GetCallHistory(DateTime inicialDate, DateTime finalDate);
    }
}