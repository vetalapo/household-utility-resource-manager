using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using HurManager.App.Common.Monads;
using HurManager.Bll.DI;
using HurManager.Dal.Context;
using HurManager.Dal.DI;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HurManager.App
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddOptions()
                .AddHttpContextAccessor()
                .AddDbContext<HurManagerContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("HurManager")))
                .AddMvc();

            this.ApplicationContainer = new ContainerBuilder()
                .Do(builder =>
                    builder
                        .RegisterModule<DalModule>()
                        .RegisterModule<BllModule>())
                .Do(builder => builder.Populate(services))
                .Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "App";
            });

            app.UseStaticFiles()
               .UseDefaultFiles();
        }
    }
}
