using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using PlanService.Models;
using PlanService.Repositories;
using PlanService.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanService.Database;
using PlanService.DateManager;
using PlanService.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PlanService.AsyncDataServices;

namespace PlanService
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

            services.Configure<PlanServiceDatabaseSettings>(
               Configuration.GetSection(nameof(PlanServiceDatabaseSettings)));

            services.AddSingleton<IPlanServiceDataBaseSettings>(sp =>
            sp.GetRequiredService<IOptions<PlanServiceDatabaseSettings>>().Value);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<DateValidator>();
            services.AddScoped<IPlanService, Services.PlanService>();
            services.AddScoped<PlanServiceDatabase>();
            services.AddScoped<IPlanRepository, PlanRepository>();


            services.AddSingleton<IMessageBusClient, MessageBusClient>(); 

            //When the time has come!

            //https://docs.duendesoftware.com/identityserver/v5/quickstarts/1_client_credentials/
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    // base-address of your identityserver
            //    options.Authority = "http//:localhost:5000";

            //    // audience is optional, make sure you read the following paragraphs
            //    // to understand your options
            //    options.TokenValidationParameters.ValidateAudience = false;

            //    // it's recommended to check the type header to avoid "JWT confusion" attacks
            //    options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
            //});


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlanService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlanService v1"));

                
            }

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
