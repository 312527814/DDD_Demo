using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Configuration;
using AspectCore.Extensions.Autofac;
using AspectCore.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyProject.Application;
using MyProject.Core;
using MyProject.Infrastructure.SqlServer;
using MyProject.SqlHelper.Dapper;

namespace MyProject.Web.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper();
            services.AddScoped((provide) =>
            {
                return new SqlConnection("Data Source=.;Database=Test;Persist Security Info=True;UID=sa;Pwd=123456");
            });
           
            services.AddTransient(typeof(CustomInterceptor));
            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);
           
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<DapperModule>();

            builder.RegisterType(typeof(CustomInterceptor)).InstancePerLifetimeScope();

            builder.RegisterDynamicProxy(config=> {
                config.Interceptors.AddTyped<CustomInterceptor>(Predicates.ForService("*Service"));
            });
            var container = builder.Build();
            var serviceProvider = new AutofacServiceProvider(container);
            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
