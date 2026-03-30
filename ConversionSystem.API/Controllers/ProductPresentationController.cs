using AutoMapper;
using ConversionSystem.API.Attribute;
using ConversionSystem.API.Infrastructures.Validator;
using ConversionSystem.API.Models;
using ConversionSystem.API.ModelsRequest.ProductPresentation;
using ConversionSystem.Service.Contracts.Interfaces;
using ConversionSystem.Service.Contracts.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace ConversionSystem.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с товарами в оформлении
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "ProductPresentation")]
    public class ProductPresentationController : ControllerBase
    {
        private readonly IProductPresentationService productPresentationService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ProductPresentationController"/>
        /// </summary>
        public ProductPresentationController(IProductPresentationService productPresentationService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.productPresentationService = productPresentationService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        /// <summary>
        /// Получить список всех товаров в оформлении
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<ProductPresentationResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await productPresentationService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<ProductPresentationResponse>>(result));
        }

        /// <summary>
        /// Получить товар в оформлении по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(ProductPresentationResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await productPresentationService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<ProductPresentationResponse>(item));
        }

        /// <summary>
        /// Создать новый товар в оформлении
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(ProductPresentationResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateProductPresentationRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var productPresentationRequestModel = mapper.Map<ProductPresentationRequestModel>(request);
            var result = await productPresentationService.AddAsync(productPresentationRequestModel, cancellationToken);
            return Ok(mapper.Map<ProductPresentationResponse>(result));
        }

        /// <summary>
        /// Редактировать товар в оформлении
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(ProductPresentationResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(ProductPresentationRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var productPresentationRequestModel = mapper.Map<ProductPresentationRequestModel>(request);
            var result = await productPresentationService.EditAsync(productPresentationRequestModel, cancellationToken);
            return Ok(mapper.Map<ProductPresentationResponse>(result));
        }

        /// <summary>
        /// Удалить товар в оформлении по id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk]
        [ApiNotFound]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await productPresentationService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
