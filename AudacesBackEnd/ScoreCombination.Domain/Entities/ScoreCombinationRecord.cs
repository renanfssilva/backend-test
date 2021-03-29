using System;

namespace ScoreCombination.Domain.Entities
{
    public class ScoreCombinationRecord
    {
        public int Id { get; set; }
        public string Sequence { get; set; }
        public long Target { get; set; }
        public string Combination { get; set; }
        public DateTime Date { get; set; }
    }
}
