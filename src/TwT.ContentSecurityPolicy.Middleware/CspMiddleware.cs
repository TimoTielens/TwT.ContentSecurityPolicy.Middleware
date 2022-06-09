using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TwT.ContentSecurityPolicy.Middleware
{
    /// <summary>
    /// Middleware that can be used to Inject a Content-Security-Policy header into the response header
    /// </summary>
    public class CspMiddleware
    {
        private const string HEADER = "Content-Security-Policy";
        private readonly RequestDelegate _next;
        private readonly CspOptions _options;

        /// <summary>
        /// Middleware that can be used to Inject a Content-Security-Policy header into the response header
        /// </summary>
        /// <param name="next">A function that can process an HTTP request</param>
        /// <param name="options">Configuration that can be used to configure the Content-Security-Policy header</param>
        public CspMiddleware(RequestDelegate next, CspOptions options)
        {
            _next = next;
            _options = options;
        }

        /// <summary>
        /// Gets called by every HTTP request
        /// </summary>
        /// <param name="context">Encapsulates all HTTP-specific information about an individual HTTP request</param>
        /// <returns>Function with the processed HTTP request</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add(HEADER, GetHeaderValue());
            await _next(context);
        }

        /// <summary>
        /// Creates the Content-Security-Policy header information
        /// </summary>
        /// <returns>Newly build Content-Security-Policy header information</returns>
        private string GetHeaderValue()
        {
            var value = "";

            //CSP Level 3 is an extension on Level 1 and 2. So if Level 3 is enabled all the other are as well
            if (_options.EnableLevel1 || _options.EnableLevel3)
            {
                value += GetDirective("default-src", _options.Defaults);
                value += GetDirective("script-src", _options.Scripts);
                value += GetDirective("style-src", _options.Styles);
                value += GetDirective("img-src", _options.Images);
                value += GetDirective("connect-src", _options.Connect);
                value += GetDirective("font-src", _options.Fonts);
                value += GetDirective("object-src", _options.Object);
            }

            //CSP Level 3 is an extension on Level 1 and 2. So if Level 3 is enabled all the other are as well
            if (_options.EnableLevel2 || _options.EnableLevel3)
            {
                value += GetDirective("child-src", _options.Child);
            }

            if (_options.EnableLevel3)
            {
                value += GetDirective("worker-src", _options.Worker);
                value += GetDirective("manifest-src", _options.Manifest);
                value += GetDirective("prefetch-src", _options.Prefetch);
            }

            //In CSP Level 2 frame-src was deprecated in favor of the child-src directive.
            //CSP Level 3, has undeprecated frame-src and it will continue to defer to child-src if not present.
            if (_options.EnableLevel3 || !_options.EnableLevel2)
            {
                value += GetDirective("frame-src", _options.Frame);
            }

            return value;
        }

        /// <summary>
        /// Creates a directive string with all the sources added to it.
        /// </summary>
        /// <param name="directive">Name of the directive that we should use.</param>
        /// <param name="sources">List of all the sources that we should add to the directive</param>
        /// <returns>Newly created directive string</returns>
        private string GetDirective(string directive, List<string> sources)
            => sources.Count > 0 ? $"{directive} {string.Join(" ", sources)}; " : "";
    }
}