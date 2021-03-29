using AutoMapper;
using ScoreCombination.Application.Dtos;
using ScoreCombination.Domain.Entities;

namespace ScoreCombination.Application.Mappers
{
    public class ModelToDtoScoreCombinationResult : Profile
    {
        public ModelToDtoScoreCombinationResult()
        {
            ScoreCombinationResultDtoMap();
        }

        private void ScoreCombinationResultDtoMap()
        {
            CreateMap<ScoreCombinationResult, ScoreCombinationResultDto>()
                .ForMember(dest => dest.Combination, opt => opt.MapFrom(src => src.Combination));
        }
    }
}
