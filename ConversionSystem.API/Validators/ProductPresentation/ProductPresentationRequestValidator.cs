using ConversionSystem.API.ModelsRequest.ProductPresentation;
using ConversionSystem.Context.Contracts.Models;
using ConversionSystem.Repositories.Contracts.Interfaces;
using FluentValidation;

namespace ConversionSystem.API.Validators.ProductPresentation
{
    /// <summary>
    /// Валидатор класса <see cref="ProductPresentationRequest"/>
    /// </summary>
    public class ProductPresentationRequestValidator : AbstractValidator<ProductPresentationRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="ProductPresentationRequestValidator"/>
        /// </summary>
        public ProductPresentationRequestValidator(IProductPresentationReadRepository productPresentationReadRepository,
            IProductReadRepository productReadRepository)
        {
            RuleFor(productPresentation => productPresentation.ProductId)
                .NotNull().WithMessage("Товар не должно быть null.")
                .NotEmpty().WithMessage("Товар не должно быть пустым.")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var productExist = await productReadRepository.AnyByIdAsync(id, CancellationToken);
                    return productExist;
                })
                .WithMessage("Такого товара не существует.");

            RuleFor(productPresentation => productPresentation.PresentationType)
                .NotNull().WithMessage("Тип не должно быть null.")
                .IsInEnum().WithMessage("Тип не существует.");

            RuleFor(productPresentation => productPresentation.ViewCount)
                .NotNull().WithMessage("Количество просмотров не должно быть null.")
                .NotEmpty().WithMessage("Количество просмотров не существует.");
        }

    }
}
