using Autofac;

namespace ScoreCombination.Infrastructure.CrossCutting.IOC
{
    public class ModuleIoc : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIoc.Load(builder);
        }
    }
}
