using Microsoft.AspNetCore.Builder;

namespace plane_a_picnic.Middleware
{
    public static class CachingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCachingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CachingMiddleware>();
        }
    }
}