using AutoMapper;
using ScoreCombination.Application.Dtos;
using ScoreCombination.Domain.Entities;

namespace ScoreCombination.Application.Mappers
{
    public class DtoToModelScoreCombinationResult : Profile
    {
        public DtoToModelScoreCombinationResult()
        {
            ScoreCombinationResultMap();
        }

        private void ScoreCombinationResultMap()
        {
            CreateMap<ScoreCombinationResultDto, ScoreCombinationResult>()
                .ForMember(dest => dest.Combination, opt => opt.MapFrom(src => src.Combination));
        }
    }
}
