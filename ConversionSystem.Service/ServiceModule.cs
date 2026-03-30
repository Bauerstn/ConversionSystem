using ConversionSystem.Common;
using ConversionSystem.Service.Automappers;
using ConversionSystem.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace ConversionSystem.Service
{
    public class ServiceModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IServiceAnchor>(ServiceLifetime.Scoped);
            service.RegisterAutoMapperProfile<ServiceProfile>();
        }
    }
}
