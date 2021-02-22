using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Rupor.Business;
using Rupor.DataAccess.RavenDb;
using Bootstrapper = Rupor.Business.Bootstrapper;
namespace Rupor.Api
{
    public class Startup
    {
        private readonly string _apiName = "Rupor core API";
        private readonly string _version = "v01";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy("AllowAllOrigins", b =>
                    {
                        b.AllowAnyMethod();
                        b.AllowAnyHeader();
                        b.AllowAnyOrigin();
                    });
                });

            services
                .AddRavenDb(_configuration)
                .AddBusiness(_configuration)
                .AddMediatR(typeof(Startup), typeof(Bootstrapper));

            #region infrastructure cfg

            services.AddControllers();
            //TODO Add newton soft json
            services.AddMvc();

            services.AddAuthentication();
            services.AddRouting();
            services.AddMemoryCache();

            services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc(_version, new OpenApiInfo() { Title = _apiName, Version = _version });
            });

            #endregion 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint($"{_version}/swagger.json", _apiName);
                });
            }

            app.UseCors(
                builder => builder.WithExposedHeaders("Content-Disposition")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            app.UseRouting();
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseEndpoints(p =>
            {
                p.MapControllers();
            });
        }
    }
}