using ConversionSystem.API.Validators.ProductPresentation;
using ConversionSystem.API.Validators.ReportResult;
using ConversionSystem.Repositories.Contracts.Interfaces;
using ConversionSystem.Service.Contracts.Exceptions;
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
            Register<CreateProductPresentationRequestValidator>(productReadRepository);
            Register<ProductPresentationRequestValidator>(productReadRepository);

            Register<CreateProductPresentationRequestValidator>(productPresentationReadRepository, productReadRepository);
            Register<ProductPresentationRequestValidator>(productPresentationReadRepository, productReadRepository);

            Register<CreateReportResultRequestValidator>(reportResultReadRepository, productPresentationReadRepository);
            Register<ReportResultRequestValidator>(reportResultReadRepository, productPresentationReadRepository);
        }

        ///<summary>
        /// Регистрирует валидатор в словаре
        /// </summary>
        public void Register<TValidator>(params object[] constructorParams)
            where TValidator : IValidator
        {
            var validatorType = typeof(TValidator);
            var innerType = validatorType.BaseType?.GetGenericArguments()[0];
            if (innerType == null)
            {
                throw new ArgumentNullException($"Указанный валидатор {validatorType} должен быть generic от типа IValidator");
            }

            if (constructorParams?.Any() == true)
            {
                var validatorObject = Activator.CreateInstance(validatorType, constructorParams);
                if (validatorObject is IValidator validator)
                {
                    validators.TryAdd(innerType, validator);
                }
            }
            else
            {
                validators.TryAdd(innerType, Activator.CreateInstance<TValidator>());
            }
        }

        public async Task ValidateAsync<TModel>(TModel model, CancellationToken cancellationToken)
            where TModel : class
        {
            var modelType = model.GetType();
            if (!validators.TryGetValue(modelType, out var validator))
            {
                throw new InvalidOperationException($"Не найден валидатор для модели {modelType}");
            }

            var context = new ValidationContext<TModel>(model);
            var result = await validator.ValidateAsync(context, cancellationToken);

            if (!result.IsValid)
            {
                throw new ConversionValidationException(result.Errors.Select(x =>
                InvalidateItemModel.New(x.PropertyName, x.ErrorMessage)));
            }
        }
    }
}
