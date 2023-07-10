using ERPeople.BLL.Exceptions;
using ERPeopleWebApi.Controllers;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ERPeopleWebApi
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try {
                await next(context);

                }
            catch (DomainNotFoundException e) 
            {

                _logger.LogError("Unhandled exception ...", e);
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(e.Message);
            }
            catch (DomainOkException e)
            {
                _logger.LogError("Unhandled exception ...", e);
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                await context.Response.WriteAsync(e.Message);
            }
            catch (DomainBadRequestException e)
            {
                _logger.LogError("Unhandled exception ...", e);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e) 
            {
                _logger.LogError("Unhandled exception ...", e);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.Message);            
            }
        }
    }
}
