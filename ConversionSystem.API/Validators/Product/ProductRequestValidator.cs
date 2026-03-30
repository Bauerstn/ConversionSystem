using ConversionSystem.API.ModelsRequest.Product;
using ConversionSystem.Repositories.Contracts.Interfaces;
using FluentValidation;

namespace ConversionSystem.API.Validators.Product
{
    /// <summary>
    /// Валидатор класса <see cref="ProductRequest"/>
    /// </summary>
    public class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        /// <summary>
        /// Инициализирует <see cref="ProductRequestValidator"/>
        /// </summary>
        public ProductRequestValidator(IProductReadRepository productReadRepository)
        {
            RuleFor(product => product.Id)
                .NotNull().WithMessage("Id не должно быть null")
                .NotEmpty().WithMessage("Id не должно быть пустым");

            RuleFor(product => product.Name)
                .NotNull().WithMessage("Имя не должно быть null.")
                .NotEmpty().WithMessage("Имя не должно быть пустым.")
                .Length(2, 200).WithMessage("Имя не должно быть меньше 2 и больше 200 символов.");

            RuleFor(product => product.ProductCount)
                .NotNull().WithMessage("Количество не должно быть null.")
                .NotEmpty().WithMessage("Количество не должно быть пустым.");
        }
    }
}
