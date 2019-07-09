using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CachingDojo.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CachingDojo
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddOData();
            services.AddAutoMapper();
            services.AddLazyCache();
            var connectionString = Configuration.GetConnectionString("CachingDojo");
            services.AddDbContext<CachingDojoContext>(options => options.UseSqlServer(connectionString));
            // register AutoMapper profiles             
            
            services
                .AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>()) // register validators                 
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);            // Register the Swagger generator 
            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Caching Dojo API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Caching Dojo API"); });
            
            app.UseHttpsRedirection();
            app.UseMvc(routeBuilder =>
            {
              /*  routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().OrderBy().Filter();*/
            });
        }
    }
}
