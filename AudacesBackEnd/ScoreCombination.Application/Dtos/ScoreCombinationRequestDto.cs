using System.Collections.Generic;

namespace ScoreCombination.Application.Dtos
{
    public class ScoreCombinationRequestDto
    {
        public List<long> Sequence { get; set; }
        public long Target { get; set; }
    }
}
