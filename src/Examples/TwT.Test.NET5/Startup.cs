using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TwT.ContentSecurityPolicy.Middleware;

namespace TwT.Test.NET5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
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
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
