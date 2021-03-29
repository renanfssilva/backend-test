using System;
using System.Collections.Generic;
using AutoMapper;
using ScoreCombination.Application.Dtos;
using ScoreCombination.Application.Interfaces;
using ScoreCombination.Domain.Entities;
using ScoreCombination.Domain.Interfaces.Services;

namespace ScoreCombination.Application
{
    public class ApplicationServiceRecord : IApplicationServiceRecord
    {
        private readonly IServiceRecord _serviceRecord;
        private readonly IMapper _mapper;

        public ApplicationServiceRecord(IServiceRecord serviceRecord, IMapper mapper)
        {
            _serviceRecord = serviceRecord;
            _mapper = mapper;
        }

        public IEnumerable<ScoreCombinationRecordDto> GetCallHistory(DateTime initialDate, DateTime finalDate)
        {
            var records = _serviceRecord.GetCallHistory(initialDate, finalDate);
            var history = _mapper.Map<IEnumerable<ScoreCombinationRecordDto>>(records);

            return history;
        }

        public ScoreCombinationResultDto Post(ScoreCombinationRequestDto requestDto)
        {
            var request = _mapper.Map<ScoreCombinationRequest>(requestDto);
            var result = _serviceRecord.GetCombination(request);
            var resultDto = _mapper.Map<ScoreCombinationResultDto>(result);

            return resultDto;
        }
    }
}
