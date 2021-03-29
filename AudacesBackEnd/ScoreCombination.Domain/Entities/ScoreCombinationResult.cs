using System.Collections.Generic;

namespace ScoreCombination.Domain.Entities
{
    public class ScoreCombinationResult
    {
        public List<long> Combination { get; set; }

        public ScoreCombinationResult()
        {
            Combination = new List<long>();
        }
    }
}