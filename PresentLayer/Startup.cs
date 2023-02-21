using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Repository;
using DataAccessLayer.DataBaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using N_tierPatterArc.AutoMapping;

namespace PresentLayer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            services.AddDbContextPool<DBContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("NtierDBConnection")));

            //dependancy injection
            
            //each request take instance of object 
            //services.AddTransient<DepartmentVM>();
           
            
            // take one instance of object  for each user
            //tightly coupled
            //services.AddScoped<DepartmentRepository>();
           
            //loosly coupled
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            // take one(shared) instance of object  for all users
            
            
            //services.AddSingleton<DepartmentVM>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PresentLayer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PresentLayer v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
