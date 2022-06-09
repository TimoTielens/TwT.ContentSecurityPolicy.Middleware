using System;
using Microsoft.AspNetCore.Builder;

namespace TwT.ContentSecurityPolicy.Middleware
{
    /// <summary>
    /// Extension that will be used to configure and load the middleware
    /// </summary>
    public static class CspMiddlewareExtensions
    {
        /// <summary>
        /// Makes sure to inject a Content-Security-Policy header into the response header
        /// </summary>
        /// <param name="app">ApplicationBuilder that we want to hook onto so we can register the middleware</param>
        /// <param name="builder">Builder that contains the options</param>
        /// <returns>ApplicationBuilder that we hooked onto</returns>
        public static IApplicationBuilder UseContentSecurityPolicyHeaderMiddelware(this IApplicationBuilder app, Action<CspOptionsBuilder> builder)
        {
            var newBuilder = new CspOptionsBuilder();
            builder(newBuilder);
            
            return app.UseMiddleware<CspMiddleware>(newBuilder.Build());
        }
    }
}