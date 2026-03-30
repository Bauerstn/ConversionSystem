using ConversionSystem.API.Infrastructures.Exceptions;
using ConversionSystem.Service.Contracts.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConversionSystem.API.Infrastructures
{
    /// <summary>
    /// Фильтр для обработки ошибок раздела администрирования
    /// </summary>
    public class ConversionExceptionFiltr : IExceptionFilter
    {
        /// <summary>
        /// Инициализирует <see cref="ConversionExceptionFiltr"/>
        /// </summary>
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception as ConversionException;
            if (exception == null)
            {
                return;
            }

            switch (exception)
            {
                case ConversionValidationException ex:
                    SetDataToContext(new ConflictObjectResult(new ApiValidationExceptionDetail
                    {
                        Errors = ex.Errors,
                    }), context);
                    break;

                case ConversionInvalidOperationException ex:
                    SetDataToContext(new BadRequestObjectResult(new ApiExceptionDetail { Message = ex.Message, })
                    {
                        StatusCode = StatusCodes.Status406NotAcceptable,
                    }, context);
                    break;

                case ConversionNotFoundException ex:
                    SetDataToContext(new NotFoundObjectResult(new ApiExceptionDetail
                    {
                        Message = ex.Message,
                    }), context);
                    break;

                default:
                    SetDataToContext(new BadRequestObjectResult(new ApiExceptionDetail
                    {
                        Message = exception.Message,
                    }), context);
                    break;
            }
        }

        /// <summary>
        /// Определяет контекст ответа
        /// </summary>
        static protected void SetDataToContext(ObjectResult data, ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = data.StatusCode ?? StatusCodes.Status400BadRequest;
            context.Result = data;
        }
    }
}
