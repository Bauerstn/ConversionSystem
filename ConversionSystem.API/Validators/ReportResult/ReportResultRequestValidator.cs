using ConversionSystem.API.ModelsRequest.ReportResult;
using ConversionSystem.Repositories.Contracts.Interfaces;
using FluentValidation;

namespace ConversionSystem.API.Validators.ReportResult
{
    /// <summary>
    /// Валидатор класса <see cref="ReportResultRequest"/>
    /// </summary>
    public class ReportResultRequestValidator : AbstractValidator<ReportResultRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="ReportResultRequestValidator"/>
        /// </summary>
        public ReportResultRequestValidator(IReportResultReadRepository reportResultReadRepository,
            IProductPresentationReadRepository productPresentationReadRepository)
        {
            RuleFor(reportResult => reportResult.Id)
                .NotNull().WithMessage("Id не должно быть null")
                .NotEmpty().WithMessage("Id не должно быть пустым");

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
