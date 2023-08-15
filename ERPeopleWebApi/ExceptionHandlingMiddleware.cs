using ERPeople.BLL.Exceptions;
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
                _logger.LogError(e, "Domain not found.");
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(e.Message);
            }
            catch (DomainBadRequestException e)
            {
                _logger.LogError(e, "Bad request in domain.");
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e) 
            {
                _logger.LogError(e, "Unhandled exception occurred.");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.Message);            
            }
        }
    }
}
