using Metsenat.Common.Exceptions;
using Metsenat.Common.Models;
using Metsenat.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Metsenat.Common.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (NotFoundException<Student> ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
        catch (NotFoundException<Sponsor> ex)
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
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var message = exception switch
        {
            NotFoundException<Student> => "Student is not found",
            NotFoundException<Sponsor> => "Sponsor is not found",
            _ => "Internal Server Error"
        };

        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        }.ToString());

    }
}