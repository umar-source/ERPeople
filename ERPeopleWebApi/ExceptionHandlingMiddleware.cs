using ERPeople.BLL.Exceptions;
using System.Net;

namespace ERPeopleWebApi
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try {
                await next(context);

                }
            catch (DomainNotFoundException e) 
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
     
                await context.Response.WriteAsync(e.Message);
            }
            catch (DomainOkException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                await context.Response.WriteAsync(e.Message);
            }
            catch (DomainBadRequestException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e) 
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
