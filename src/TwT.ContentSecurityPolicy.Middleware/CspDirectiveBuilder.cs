using System.Collections.Generic;

namespace TwT.ContentSecurityPolicy.Middleware
{
    /// <summary>
    /// Builder that can be used to build a Directive
    /// </summary>
    public sealed class CspDirectiveBuilder
    {
        /// <summary>
        /// List of all the Allowed items
        /// </summary>
        internal List<string> Sources { get; set; } = new List<string>();

        /// <summary>
        /// Wildcard, allows any URL except data: blob: filesystem: schemes.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder Wildcard() => Allow("*");

        /// <summary>
        /// Prevents loading resources from any source.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder AllowNone() => Allow("none");

        /// <summary>
        /// Allows loading resources from the same origin (same scheme, host and port).
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder AllowSelf() => Allow("'self'");

        /// <summary>
        /// Allows loading resources from the specified domain name.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder AllowData() => Allow("data:");

        /// <summary>
        /// Allows loading resources only over HTTPS on any domain.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder AllowHtppsOnly() => Allow("https:");

        /// <summary>
        /// Allows use of inline source elements such as style attribute, onclick, or script tag bodies (depends on the context of the source it is applied to) and javascript: URIs
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder AllowUnsafeInline() => Allow("'unsafe-inline'");

        /// <summary>
        /// Allows unsafe dynamic code evaluation such as JavaScript eval()
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder AllowUnsafeEval() => Allow("'unsafe-eval'");

        /// <summary>
        /// Enables an allowed script to load additional scripts via non-"parser-inserted" script elements (for example document.createElement('script'); is allowed).
        /// </summary>
        /// <remarks>CSP Level 3</remarks>
        public CspDirectiveBuilder AllowStrictDynamic() => Allow("'strict-dynamic'");

        /// <summary>
        /// Allows you to enable scripts in event handlers (eg onclick). Does not apply to javascript: or inline script
        /// </summary>
        /// <remarks>CSP Level 3</remarks>
        public CspDirectiveBuilder AllowUnsafeHashes() => Allow("'unsafe-hashes'");

        /// <summary>
        /// Adds an item to the allowed sources list
        /// </summary>
        /// <param name="source">Source that should be added to the list</param>
        /// <returns>CspDirectiveBuilder</returns>
        public CspDirectiveBuilder Allow(string source)
        {
            Sources.Add(source);
            return this;
        }
    }
}