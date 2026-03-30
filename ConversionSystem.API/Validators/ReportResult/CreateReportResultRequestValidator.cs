using ConversionSystem.API.ModelsRequest.ReportResult;
using ConversionSystem.Repositories.Contracts.Interfaces;
using FluentValidation;

namespace ConversionSystem.API.Validators.ReportResult
{
    /// <summary>
    /// Валидатор класса <see cref="CreateReportResultRequest"/>
    /// </summary>
    public class CreateReportResultRequestValidator : AbstractValidator<CreateReportResultRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="CreateReportResultRequestValidator"/>
        /// </summary>
        public CreateReportResultRequestValidator(IReportResultReadRepository reportResultReadRepository,
            IProductPresentationReadRepository productPresentationReadRepository)
        {
            RuleFor(reportResult => reportResult.ProductPresentationId)
                .NotNull().WithMessage("Оформление товара не должно быть null.")
                .NotEmpty().WithMessage("Оформление товара не должно быть пустым.")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var productPresentationExist = await productPresentationReadRepository.AnyByIdAsync(id, CancellationToken);
                    return productPresentationExist;
                })
                .WithMessage("Такого оформления товара не существует.");
        }
    }
}