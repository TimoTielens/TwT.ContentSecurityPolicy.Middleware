using System.Collections.Generic;

namespace TwT.ContentSecurityPolicy.Middleware
{
    /// <summary>
    /// Configuration that can be used to configure the Content-Security-Policy header
    /// </summary>
    public sealed class CspOptions
    {
        #region CSP Level 1

        /// <summary>
        /// Specifies if CSP Level 1 headers should be used
        /// </summary>
        public bool EnableLevel1 { get; set; }

        /// <summary>
        /// The default-src directive defines the default policy for fetching resources such as JavaScript, Images, CSS, Fonts, AJAX requests, Frames, HTML5 Media.
        /// </summary>
        /// <remarks>CSP Level 1| Not all directives fallback to default-src</remarks>
        public List<string> Defaults { get; set; } = new List<string>();

        /// <summary>
        /// Defines valid sources of JavaScript.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public List<string> Scripts { get; set; } = new List<string>();

        /// <summary>
        /// Defines valid sources of stylesheets or CSS.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public List<string> Styles { get; set; } = new List<string>();

        /// <summary>
        /// Defines valid sources of images.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public List<string> Images { get; set; } = new List<string>();

        /// <summary>
        /// Applies to XMLHttpRequest (AJAX), WebSocket, fetch(), ping or EventSource. If not allowed the browser emulates a 400 HTTP status code.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public List<string> Connect { get; set; } = new List<string>();

        /// <summary>
        /// Defines valid sources of font resources (loaded via @font-face).
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public List<string> Fonts { get; set; } = new List<string>();

        /// <summary>
        /// Defines valid sources of plugins, eg object, embed or applet.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public List<string> Object { get; set; } = new List<string>();

        /// <summary>
        /// Defines valid sources of audio and video, eg HTML5 audio, video elements.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public List<string> Media { get; set; } = new List<string>();

        /// <summary>
        /// Defines valid sources for loading frames.
        /// </summary>
        /// <remarks>In CSP Level 2 frame-src was deprecated in favor of the child-src directive. CSP Level 3, has undeprecated frame-src and it will continue to defer to child-src if not present.</remarks>>
        public List<string> Frame { get; set; } = new List<string>();

        #endregion

        #region CSP Level 2
        /// <summary>
        /// Specifies if CSP Level 2 headers should be used
        /// </summary>
        public bool EnableLevel2 { get; set; } = true;

        /// <summary>
        /// Defines valid sources for web workers and nested browsing contexts loaded using elements such as frame and iframe
        /// </summary>
        /// <remarks>CSP Level 2</remarks>
        public List<string> Child { get; set; } = new List<string>();
        #endregion

        #region CSP Level 3
        /// <summary>
        /// Specifies if CSP Level 3 headers should be used
        /// </summary>
        public bool EnableLevel3 { get; set; } = true;

        /// <summary>
        /// Restricts the URLs which may be loaded as a Worker, SharedWorker or ServiceWorker.
        /// </summary>
        /// <remarks>CSP Level 3</remarks>
        public List<string> Worker { get; set; } = new List<string>();

        /// <summary>
        /// Restricts the URLs that application manifests can be loaded.
        /// </summary>
        /// <remarks>CSP Level 3</remarks>
        public List<string> Manifest { get; set; } = new List<string>();

        /// <summary>
        /// Defines valid sources for request prefetch and prerendering, for example via the link tag with rel="prefetch" or rel="prerender":
        /// </summary>
        /// <remarks>CSP Level 3</remarks>
        public List<string> Prefetch { get; set; } = new List<string>();
        #endregion

    }
}