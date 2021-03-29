using AutoMapper;
using ScoreCombination.Application.Dtos;
using ScoreCombination.Domain.Entities;

namespace ScoreCombination.Application.Mappers
{
    public class DtoToModelScoreCombinationRequest : Profile
    {
        public DtoToModelScoreCombinationRequest()
        {
            ScoreCombinationRequestMap();
        }

        private void ScoreCombinationRequestMap()
        {
            CreateMap<ScoreCombinationRequestDto, ScoreCombinationRequest>()
                .ForMember(dest => dest.Sequence, opt => opt.MapFrom(src => src.Sequence))
                .ForMember(dest => dest.Target, opt => opt.MapFrom(src => src.Target));
        }
    }
}
