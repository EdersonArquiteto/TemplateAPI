using FluentValidation;
using Newtonsoft.Json;

using System.Net;
using TemplateAPI.Domain.Core;

namespace TemplateAPI.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// M�todo utilizado para capturar os eventos da API
        /// </summary>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DomainException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var message = string.Empty;

            switch (exception)
            {
                //Exce��o gerada pelo Dom�nio (regras de neg�cio)
                case DomainException:
                    context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    message = exception.Message;
                    break;

                //Exce��o gerada pelo FluentValidation (regras de valida��o)
                case ValidationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    message = JsonConvert.SerializeObject(((ValidationException)exception).Errors);
                    break;

                //Exce��o do servidor
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    break;
            }

            //Retornando a resposta de erro
            await context.Response.WriteAsync(new ErrorDetailsModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }

    public class ErrorDetailsModel
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
