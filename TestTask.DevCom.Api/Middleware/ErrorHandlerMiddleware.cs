using System.Net;
using Newtonsoft.Json;
using TestTask.DevCom.Common.Exceptions;

namespace TestTask.DevCom.Api.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (ex)
            {
                case NotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                
                case EntityAlreadyExistException e:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;

                case InvalidOperationException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonConvert.SerializeObject(new { message = ex?.Message });
            await response.WriteAsync(result);
        }
    }
    
}