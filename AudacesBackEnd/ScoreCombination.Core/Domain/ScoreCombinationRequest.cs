using System.Collections.Generic;

namespace ScoreCombination.Core.Domain
{
    public class ScoreCombinationRequest
    {
        public List<long> Sequence { get; set; }
        public long Target { get; set; }

        public ScoreCombinationRequest()
        {
            Sequence = new List<long>();
        }
    }
}