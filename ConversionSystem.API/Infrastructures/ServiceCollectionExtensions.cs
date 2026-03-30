using ConversionSystem.API.Infrastructures.Validator;
using ConversionSystem.Common;
using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Context;
using ConversionSystem.Repositories;
using ConversionSystem.Service;
using ConversionSystem.Shared;

namespace ConversionSystem.API.Infrastructures
{
    static internal class ServiceCollectionExtensions
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            service.AddTransient<IDateTimeProvider, DateTimeProvider>();
            service.AddTransient<IDbWriterContext, DbWriterContext>();
            service.AddTransient<IApiValidatorService, ApiValidatorService>();
            service.RegisterAutoMapperProfile<ApiAutoMapperProfile>();

            service.RegisterModule<ServiceModule>();
            service.RegisterModule<RepositoryModule>();
            service.RegisterModule<ContextModule>();

            service.RegisterAutoMapper();
        }
    }
}
