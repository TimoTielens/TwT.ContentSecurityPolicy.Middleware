# TwT.ContentSecurityPolicy.Middleware

## Introductie
Very simple middleware project that can be used to inject a Content-Security-Policy into the response header. It supports al the *-src options for CSP Level 1, 2 and 3. See the following [LINK](https://content-security-policy.com/) for more information.

The project is build in .NET CORE 3.1. It also contains two example projects. Those projects are Configured in .NET 5 and .NET 6. 

## Usage
You can use this middleware by calling 'UseContentSecurityPolicyHeaderMiddelware' on the Startup file of your ASP.NET project

`
            app.UseContentSecurityPolicyHeaderMiddelware(builder =>
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
