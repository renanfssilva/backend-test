﻿using AutoMapper;
using ScoreCombination.Application.Dtos;
using ScoreCombination.Domain.Entities;

namespace ScoreCombination.Application.Mappers
{
    public class ModelToDtoScoreCombinationRecord : Profile
    {
        public ModelToDtoScoreCombinationRecord()
        {
            ScoreCombinationRecordDtoMap();
        }

        private void ScoreCombinationRecordDtoMap()
        {
            CreateMap<ScoreCombinationRecord, ScoreCombinationRecordDto>()
                .ForMember(dest => dest.Sequence, opt => opt.MapFrom(src => src.Sequence))
                .ForMember(dest => dest.Target, opt => opt.MapFrom(src => src.Target))
                .ForMember(dest => dest.Combination, opt => opt.MapFrom(src => src.Combination))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));
        }
    }
}