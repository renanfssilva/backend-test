using System.Collections.Generic;

namespace ScoreCombination.Core.Domain
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