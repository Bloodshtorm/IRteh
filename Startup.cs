using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using System.IO;

namespace IRteh
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
            services.AddControllers();
            //services.AddMvc();
            //services.AddSingleton<IConfigurationBuilder, ConfigurationBuilder>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Notes API1", Version = "v1" 
                });

                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Notes API2",
                    Version = "v2"
                });
                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "IRteh.xml"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            //app.UseSwaggerUI();
            app.UseSwaggerUI
            (config=>
                {
                    //для того что бы открывалась по-умолчанию swagger/v1/swagger.json
                    config.SwaggerEndpoint("v1/swagger.json", "Notes API1");
                    config.SwaggerEndpoint("v2/swagger.json", "Notes API2");
                }
            );

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
