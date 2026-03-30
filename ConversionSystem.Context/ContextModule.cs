using ConversionSystem.Common;
using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Context.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ConversionSystem.Context
{
    public class ContextModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.TryAddScoped<IConversionSystemContext>(provider => provider.GetRequiredService<ConversionSystemContext>());
            service.TryAddScoped<IDbReader>(provider => provider.GetRequiredService<ConversionSystemContext>());
            service.TryAddScoped<IDbWriter>(provider => provider.GetRequiredService<ConversionSystemContext>());
            service.TryAddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ConversionSystemContext>());
        }
    }
}
