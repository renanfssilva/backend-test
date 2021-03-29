using AutoMapper;
using ScoreCombination.Application.Dtos;
using ScoreCombination.Domain.Entities;

namespace ScoreCombination.Application.Mappers
{
    public class ModelToDtoScoreCombinationRequest : Profile
    {
        public ModelToDtoScoreCombinationRequest()
        {
            ScoreCombinationRequestDtoMap();
        }

        private void ScoreCombinationRequestDtoMap()
        {
            CreateMap<ScoreCombinationRequest, ScoreCombinationRequestDto>()
                .ForMember(dest => dest.Sequence, opt => opt.MapFrom(src => src.Sequence))
                .ForMember(dest => dest.Target, opt => opt.MapFrom(src => src.Target));
        }
    }
}
