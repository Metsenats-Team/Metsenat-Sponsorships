using Metsenat.Common.Middlewares;

namespace Metsenat.Api.Extensions;
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionMiddleware>();
    }
}
