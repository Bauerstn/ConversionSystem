using ConversionSystem.Repositories.Contracts.Interfaces;
using ConversionSystem.Shared;
using FluentValidation;

namespace ConversionSystem.API.Infrastructures.Validator
{
    internal sealed class ApiValidatorService : IApiValidatorService
    {
        private readonly Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        public ApiValidatorService(IProductReadRepository productReadRepository,
            IProductPresentationReadRepository productPresentationReadRepository,
            IReportResultReadRepository reportResultReadRepository)
        {
            Register<Crea
        }
    }
}
