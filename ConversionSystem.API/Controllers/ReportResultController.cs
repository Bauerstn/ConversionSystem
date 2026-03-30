using AutoMapper;
using ConversionSystem.API.Attribute;
using ConversionSystem.API.Infrastructures.Validator;
using ConversionSystem.API.Models;
using ConversionSystem.API.ModelsRequest.ReportResult;
using ConversionSystem.Service.Contracts.Interfaces;
using ConversionSystem.Service.Contracts.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace ConversionSystem.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с отчетами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "ReportResult")]
    public class ReportResultController : Controller
    {
        private readonly IReportResultService reoportResultService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ReportResultController"/>
        /// </summary>
        public ReportResultController(IReportResultService reoportResultService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.reoportResultService = reoportResultService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        /// <summary>
        /// Получить список всех отчетов
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(IEnumerable<ReportResultResponse>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await reoportResultService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<ReportResultResponse>>(result));
        }

        /// <summary>
        /// Получить отчет по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ApiOk(typeof(ReportResultResponse))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await reoportResultService.GetByIdAsync(id, cancellationToken);
            return Ok(mapper.Map<ReportResultResponse>(item));
        }

        /// <summary>
        /// Создать новый отчет
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(ReportResultResponse))]
        [ApiConflict]
        public async Task<IActionResult> Create(CreateReportResultRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var reportResultRequestModel = mapper.Map<ReportResultRequestModel>(request);
            var result = await reoportResultService.AddAsync(reportResultRequestModel, cancellationToken);
            return Ok(mapper.Map<ReportResultResponse>(result));
        }

        /// <summary>
        /// Редактировать отчет
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(ReportResultResponse))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(ReportResultRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);
            var reportResultRequestModel = mapper.Map<ReportResultRequestModel>(request);
            var result = await reoportResultService.EditAsync(reportResultRequestModel, cancellationToken);
            return Ok(mapper.Map<ReportResultResponse>(result));
        }

        /// <summary>
        /// Удалить товар по id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ApiOk]
        [ApiNotFound]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await reoportResultService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
