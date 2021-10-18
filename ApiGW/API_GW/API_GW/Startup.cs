using Figgle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GW
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                // Replce http://localhost:23824 in WithOrigins to frontend ULR
                options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader()
                );
            });
            services.AddOcelot();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(FiggleFonts.Isometric3.Render("HELLO!"));
                    await context.Response.WriteAsync("\n \n");
                    await context.Response.WriteAsync(FiggleFonts.Isometric3.Render("THIS IS APIGW"));
                    await context.Response.WriteAsync("\n \n");
                    await context.Response.WriteAsync(FiggleFonts.Isometric3.Render("WELCOME TO"));
                    await context.Response.WriteAsync("\n \n");
                    await context.Response.WriteAsync(FiggleFonts.Isometric3.Render("FRONT END STRATEGY!"));
                    await context.Response.WriteAsync("\n \n");
                    await context.Response.WriteAsync(FiggleFonts.Isometric3.Render(" :) "));
                });
            });

            app.UseOcelot().Wait();
        }
    }
}
