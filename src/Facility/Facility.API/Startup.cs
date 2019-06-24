using Autofac;
using Autofac.Extensions.DependencyInjection;
using Envision.MDM.Location.API.Helper.AutoFacModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Envision.MDM.Location.API
{
    [ExcludeFromCodeCoverage]
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options => {
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)
                    (resolver as DefaultContractResolver).NamingStrategy = null;
            });

            //Register the Swagger Services
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Facility API";
                    document.Info.Description = "This a microservices that provide all end points related to " +
                                                        "Facilities data management";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Envision Physician Services ",
                        Email = string.Empty,
                        Url = string.Empty,
                    };
                };
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
           

            //Dependency Injection using Autofac
            //configure autoFac 
            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));

            return new AutofacServiceProvider(container.Build());

        }

        // This method gets called by the runtime. 
        //Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
