using System.Collections.Generic;

namespace ScoreCombination.Domain.Entities
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