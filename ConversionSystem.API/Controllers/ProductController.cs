using AutoMapper;
using ConversionSystem.API.Attribute;
using ConversionSystem.API.Infrastructures.Validator;
using ConversionSystem.API.Models;
using ConversionSystem.API.ModelsRequest.Product;
using ConversionSystem.Service.Contracts.Interfaces;
using ConversionSystem.Service.Contracts.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace ConversionSystem.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с товарами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ProductController"/>
        /// </summary>
        public ProductController(IProductService productService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        /// <summary>
        /// Получить список всех товаров
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<ProductResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await productService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<ProductResponse>>(result));
        }

        /// <summary>
        /// Получить товар по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(ProductResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await productService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<ProductResponse>(item));
        }

        /// <summary>
        /// Создать новый товар
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(ProductResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateProductRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var productRequestModel = mapper.Map<ProductRequestModel>(request);
            var result = await productService.AddAsync(productRequestModel, cancellationToken);
            return Ok(mapper.Map<ProductResponse>(result));
        }

        /// <summary>
        /// Редактировать товар
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(ProductResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(ProductRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var productRequestModel = mapper.Map<ProductRequestModel>(request);
            var result = await productService.EditAsync(productRequestModel, cancellationToken);
            return Ok(mapper.Map<ProductResponse>(result));
        }

        /// <summary>
        /// Удалить товар по id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk]
        [ApiNotFound]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await productService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
