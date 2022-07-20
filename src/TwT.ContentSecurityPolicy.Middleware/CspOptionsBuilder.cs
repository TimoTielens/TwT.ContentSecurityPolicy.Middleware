namespace TwT.ContentSecurityPolicy.Middleware
{
    /// <summary>
    /// Builder that builds up the options
    /// </summary>
    public sealed class CspOptionsBuilder
    {
        private readonly CspOptions _options = new CspOptions();

        #region CSP Level 1
        /// <summary>
        /// Specifies if CSP Level 1 headers should be used
        /// </summary>
        public bool EnableLevel1 { get; } = true;

        /// <summary>
        /// The default-src directive defines the default policy for fetching resources such as JavaScript, Images, CSS, Fonts, AJAX requests, Frames, HTML5 Media.
        /// </summary>
        /// <remarks>CSP Level 1| Not all directives fallback to default-src</remarks>
        public CspDirectiveBuilder Defaults { get; set; } = new CspDirectiveBuilder();

        /// <summary>
        /// Defines valid sources of JavaScript.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder Scripts { get; set; } = new CspDirectiveBuilder();

        /// <summary>
        /// Defines valid sources of stylesheets or CSS.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder Styles { get; set; } = new CspDirectiveBuilder();

        /// <summary>
        /// Defines valid sources of images.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder Images { get; set; } = new CspDirectiveBuilder();

        /// <summary>
        /// Applies to XMLHttpRequest (AJAX), WebSocket, fetch(), ping or EventSource. If not allowed the browser emulates a 400 HTTP status code.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder Connect { get; set; } = new CspDirectiveBuilder();

        /// <summary>
        /// Defines valid sources of font resources (loaded via @font-face).
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder Fonts { get; set; } = new CspDirectiveBuilder();

        /// <summary>
        /// Defines valid sources of plugins, eg object, embed or applet.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder Object { get; set; } = new CspDirectiveBuilder();

        /// <summary>
        /// Defines valid sources of audio and video, eg HTML5 audio, video elements.
        /// </summary>
        /// <remarks>CSP Level 1</remarks>
        public CspDirectiveBuilder Media { get; set; } = new CspDirectiveBuilder();

        /// <summary>
        /// Defines valid sources for loading frames.
        /// </summary>
        /// <remarks>In CSP Level 2 frame-src was deprecated in favor of the child-src directive. CSP Level 3, has undeprecated frame-src and it will continue to defer to child-src if not present.</remarks>>
        public CspDirectiveBuilder Frame { get; set; } = new CspDirectiveBuilder();

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
        public CspDirectiveBuilder Child { get; set; } = new CspDirectiveBuilder();

        #endregion
        #region CSP Level 3
        /// <summary>
        /// Specifies if CSP Level 3 headers should be used
        /// </summary>
        public bool EnableLevel3 { get; set; } = true;

        /// <summary>
        /// Defines valid sources for web workers and nested browsing contexts loaded using elements such as frame and iframe
        /// </summary>
        /// <remarks>CSP Level 2</remarks>
        public CspDirectiveBuilder Worker { get; set; } = new CspDirectiveBuilder();

        /// <summary>
        /// Restricts the URLs that application manifests can be loaded.
        /// </summary>
        /// <remarks>CSP Level 2</remarks>
        public CspDirectiveBuilder Manifest { get; set; } = new CspDirectiveBuilder();

        /// <summary>
        /// Defines valid sources for request prefetch and prerendering, for example via the link tag with rel="prefetch" or rel="prerender":
        /// </summary>
        /// <remarks>CSP Level 2</remarks>
        public CspDirectiveBuilder Prefetch { get; set; } = new CspDirectiveBuilder();

        #endregion

        /// <summary>
        /// Builds the options set
        /// </summary>
        /// <returns>Configured option set</returns>
        public CspOptions Build()
        {
            _options.EnableLevel1 = EnableLevel1;
            _options.Defaults = Defaults.Sources;
            _options.Scripts = Scripts.Sources;
            _options.Styles = Styles.Sources;
            _options.Images = Images.Sources;
            _options.Connect = Connect.Sources;
            _options.Fonts = Fonts.Sources;
            _options.Object = Object.Sources;
            _options.Media = Media.Sources;
            _options.Frame = Frame.Sources;

            _options.EnableLevel2 = EnableLevel2;
            _options.Child = Child.Sources;


            _options.EnableLevel3 = EnableLevel3;
            _options.Worker = Worker.Sources;
            _options.Manifest = Manifest.Sources;
            _options.Prefetch = Prefetch.Sources;

            return _options;
        }
    }
}