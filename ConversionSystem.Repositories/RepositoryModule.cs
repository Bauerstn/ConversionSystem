using ConversionSystem.Common;
using ConversionSystem.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace ConversionSystem.Repositories
{
    public class RepositoryModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IRepositoryAnchor>(ServiceLifetime.Scoped);
        }
    }
}
