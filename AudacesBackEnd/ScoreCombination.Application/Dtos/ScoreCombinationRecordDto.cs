using System;
using System.Collections.Generic;

namespace ScoreCombination.Application.Dtos
{
    public class ScoreCombinationRecordDto
    {
        public List<long> Sequence { get; set; }
        public long Target { get; set; }
        public List<long> Combination { get; set; }
        public DateTime Date { get; set; }
    }
}
