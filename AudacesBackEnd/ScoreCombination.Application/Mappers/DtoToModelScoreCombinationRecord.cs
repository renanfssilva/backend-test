using AutoMapper;
using ScoreCombination.Application.Dtos;
using ScoreCombination.Domain.Entities;

namespace ScoreCombination.Application.Mappers
{
    public class DtoToModelScoreCombinationRecord : Profile
    {
        public DtoToModelScoreCombinationRecord()
        {
            ScoreCombinationRecordMap();
        }

        private void ScoreCombinationRecordMap()
        {
            CreateMap<ScoreCombinationRecordDto, ScoreCombinationRecord>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Sequence, opt => opt.MapFrom(src => string.Join(',', src.Sequence)))
                .ForMember(dest => dest.Target, opt => opt.MapFrom(src => src.Target))
                .ForMember(dest => dest.Combination, opt => opt.MapFrom(src => string.Join(',', src.Combination)))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));
        }
    }
}
