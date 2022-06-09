# TwT.ContentSecurityPolicy.Middleware

## Introductie
Very simple middleware project that can be used to inject a Content-Security-Policy into the response header. It supports al the *-src options for CSP Level 1, 2 and 3. See the following [LINK](https://content-security-policy.com/) for more information.

The project is build in .NET CORE 3.1. It also contains two example projects. Those projects are Configured in .NET 5 and .NET 6. 

## Supported Content-Security-Policy options

| CSP Directive    |      Description      | CSP Level | Supported | 
|----------|:-------------:|------:|------:|
| default-src |  Defines the default policy for fetching resources such as JavaScript, Images, CSS, Fonts, AJAX requests, Frames, HTML5 Media. | 1 | &#9745; |
| script-src |    Defines valid sources of JavaScript.   |   1 | &#9745; |
| style-src | Defines valid sources of stylesheets or CSS. |    1 | &#9745; |
| img-src | Defines valid sources of images. |    1 | &#9745; |
| connect-src | Applies to XMLHttpRequest (AJAX), WebSocket, fetch(), <a ping> or EventSource. If not allowed the browser emulates a 400 HTTP status code. |    1 | &#9745; |
| font-src | Defines valid sources of font resources (loaded via @font-face). |    1 | &#9745; |
| object-src | Defines valid sources of plugins, eg <object>, <embed> or <applet>. |    1 | &#9745; |
| media-src | Defines valid sources of audio and video, eg HTML5 <audio>, <video> elements. |    1 | &#9745; |
| frame-src | efines valid sources for loading frames. In CSP Level 2 frame-src was deprecated in favor of the child-src directive. CSP Level 3, has undeprecated frame-src and it will continue to defer to child-src if not present. |    1 | &#9745; |
| sandbox | Enables a sandbox for the requested resource similar to the iframe sandbox attribute. The sandbox applies a same origin policy, prevents popups, plugins and script execution is blocked. You can keep the sandbox value empty to keep all restrictions in place, or add values: allow-forms allow-same-origin allow-scripts allow-popups, allow-modals, allow-orientation-lock, allow-pointer-lock, allow-presentation, allow-popups-to-escape-sandbox, and allow-top-navigation |    1 | &#9744; |
| report-uri | Instructs the browser to POST a reports of policy failures to this URI. You can also use Content-Security-Policy-Report-Only as the HTTP header name to instruct the browser to only send reports (does not block anything). This directive is deprecated in CSP Level 3 in favor of the report-to directive. |    1 | &#9744; |
| child-src | Defines valid sources for web workers and nested browsing contexts loaded using elements such as <frame> and <iframe> |  2 | &#9745; |
| form-action | Defines valid sources that can be used as an HTML <form> action. |  2 | &#9744; |
| frame-ancestors | Defines valid sources for embedding the resource using <frame> <iframe> <object> <embed> <applet>. Setting this directive to 'none' should be roughly equivalent to X-Frame-Options: DENY |  2 | &#9744; |
| plugin-types | Defines valid MIME types for plugins invoked via <object> and <embed>. To load an <applet> you must specify application/x-java-applet. |  2 | &#9744; |
| base-uri | Defines a set of allowed URLs which can be used in the src attribute of a HTML base tag. |  2 | &#9744; |
| report-to | Defines a reporting group name defined by a Report-To HTTP response header. See the Reporting API for more info. |  3 | &#9744; |
| worker-src | Restricts the URLs which may be loaded as a Worker, SharedWorker or ServiceWorker.|  3 | &#9745; |
| manifest-src | Restricts the URLs that application manifests can be loaded. |  3 | &#9745; |
| prefetch-src | Defines valid sources for request prefetch and prerendering, for example via the link tag with rel="prefetch" or rel="prerender": |  3 | &#9745; |
| navigate-to | Restricts the URLs that the document may navigate to by any means. For example when a link is clicked, a form is submitted, or window.location is invoked. If form-action is present then this directive is ignored for form submissions. |  3 | &#9744; |


## Usage
You can use this middleware by calling 'UseContentSecurityPolicyHeaderMiddelware' on the Startup file of your ASP.NET project

`   app.UseContentSecurityPolicyHeaderMiddelware(builder =>
            {
                #region CSP Level 1
                //Level1 is always enabled!
                builder.Defaults
                    .AllowSelf();

                builder.Scripts
                    .AllowSelf();

                builder.Styles
                    .AllowSelf();

                builder.Images
                    .AllowSelf();

                builder.Connect
                    .AllowSelf();

                builder.Fonts
                    .AllowSelf();

                builder.Object
                    .AllowSelf();

                builder.Media
                    .AllowSelf();

                builder.Frame
                    .AllowSelf();
                #endregion

                #region CSP Level 2
                builder.EnableLevel2 = true;

                builder.Child
                    .AllowSelf();
                #endregion

                #region CSP Level 3
                builder.EnableLevel3 = true;

                builder.Worker
                    .AllowSelf();

                builder.Manifest
                    .AllowSelf();

                builder.Prefetch
                    .AllowSelf();
                #endregion
            });`