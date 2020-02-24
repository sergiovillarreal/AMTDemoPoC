using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmtDirectCalculator.Core.Services;
using AmtDirectCalculator.SharedKernel.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AmtDirectCalculator.Api
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
            services.TryAddSingleton<IBaseCalculatorService, BaseCalculatorService>();
            services.AddControllers();
            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "AMT Direct API";
                    document.Info.Description = "AMT Direct API for Calculations";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "AMT Direct",
                        Email = string.Empty,
                        Url = "https://www.AmtDirectCalculatorcom/contact-amtdirect"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under AMT license   ",
                        Url = "https://www.AmtDirectCalculatorcom/contact-amtdirect"
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi(); // serve documents (same as app.UseSwagger())
            app.UseSwaggerUi3(); // serve Swagger UI

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
