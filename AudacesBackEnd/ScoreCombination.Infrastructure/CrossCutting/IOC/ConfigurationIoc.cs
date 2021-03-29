using Autofac;
using AutoMapper;
using ScoreCombination.Application;
using ScoreCombination.Application.Interfaces;
using ScoreCombination.Application.Mappers;
using ScoreCombination.Domain.Interfaces.Repositories;
using ScoreCombination.Domain.Interfaces.Services;
using ScoreCombination.Domain.Services;
using ScoreCombination.Infrastructure.Data.Repositories;

namespace ScoreCombination.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIoc
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationServiceRecord>().As<IApplicationServiceRecord>();
            builder.RegisterType<ServiceRecord>().As<IServiceRecord>();
            builder.RegisterType<RepositoryRecord>().As<IRepositoryRecord>();
            builder.Register(context => new MapperConfiguration(config =>
            {
                config.AddProfile(new DtoToModelScoreCombinationRecord());
            }));

            builder.Register(context => context.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
