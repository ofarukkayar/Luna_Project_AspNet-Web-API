using Luna_Project_AspNet_Web_API.Core.Repositories;
using Luna_Project_AspNet_Web_API.Core.Services;
using Luna_Project_AspNet_Web_API.Core.UnitOfWorks;
using Luna_Project_AspNet_Web_API.Data;
using Luna_Project_AspNet_Web_API.Data.Repositories;
using Luna_Project_AspNet_Web_API.Data.UnitOfWorks;
using Luna_Project_AspNet_Web_API.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Luna_Project_AspNet_Web_API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using Luna_Project_AspNet_Web_API.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Luna_Project_AspNet_Web_API.Extensions;

namespace Luna_Project_AspNet_Web_API
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
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<ProductNotFoundFilter>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o => 
                {
                    o.MigrationsAssembly("Luna_Project_AspNet-Web-API.Data");
                });
            });

            
            services.AddControllers(o => {
                o.Filters.Add(new ValidationFilter());
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException();

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
