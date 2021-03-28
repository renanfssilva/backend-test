using System;
using System.Collections.Generic;

namespace ScoreCombination.Core.Domain
{
    public class ScoreCombinationRecord
    {
        public int Id { get; set; }
        public List<long> Sequence { get; set; }
        public long Target { get; set; }
        public List<long> Combination { get; set; }
        public DateTime Date { get; set; }
    }
}
