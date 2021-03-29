using System;
using System.Collections.Generic;
using ScoreCombination.Application.Dtos;

namespace ScoreCombination.Application.Interfaces
{
    public interface IApplicationServiceRecord
    {
        IEnumerable<ScoreCombinationRecordDto> GetCallHistory(DateTime initialDate, DateTime finalDate);
        ScoreCombinationResultDto Post(ScoreCombinationRequestDto request);
    }
}
