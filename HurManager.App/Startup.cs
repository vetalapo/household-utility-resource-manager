using Autofac;
using Autofac.Extensions.DependencyInjection;

using HurManager.App.DI;
using HurManager.Bll.DI;
using HurManager.Dal.Context;
using HurManager.Dal.DI;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HurManager.App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/wwwroot";
            });

            services
                .AddAutofac()
                .AddOptions()
                .AddHttpContextAccessor()
                .AddDbContext<HurManagerContext>(
                    options => 
                    options
                        .UseSqlServer(
                            this.Configuration.GetConnectionString("HurManager"),
                            p => p.EnableRetryOnFailure()))
                .AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                //{
                //    HotModuleReplacement = true
                //});
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "api/{controller}/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "api-fallback",
                    pattern: "api/{*.}",
                    new { controller = "Home", action = "ApiNotFound" });

                endpoints.MapControllerRoute(
                    name: "def-fallback",
                    pattern: "{*.}",
                    new { controller = "Home", action = "Index" });
            });

            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //    }
            //});
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder
                .RegisterModule<AutomapperModule>()
                .RegisterModule<DalModule>()
                .RegisterModule<BllModule>();
        }
    }
}
