using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCaching;

namespace plane_a_picnic.Settings.Middleware
{
    public class CachingMiddleware
{
   private readonly RequestDelegate _next;

   public CachingMiddleware(RequestDelegate next)
   {
      _next = next;
   }

   public async Task Invoke(HttpContext context)
   {
      // Note that the middleware ignores requests doesn't return 200 (OK)
      context.Response.GetTypedHeaders().CacheControl =
      new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
      {
         Public = true,
         MaxAge = TimeSpan.FromSeconds(3600)
      };
      var responseCachingFeature = context.Features.Get<IResponseCachingFeature>();
      if (responseCachingFeature != null)
      {
         responseCachingFeature.VaryByQueryKeys = new[] { "api" };
      }
      await _next(context);
   } 
}
}