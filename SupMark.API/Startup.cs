using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SupMark.Infrastructure.DataAccess;
using SupMark.Services.Implementations;
using SupMark.Services.Implementations.Mock;
using SupMark.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupMark.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SupMarkDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddOptions();
            services.AddMvc().AddNewtonsoftJson();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SupMark.API", Version = "v1" });
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var options = new DbContextOptionsBuilder<SupMarkDbContext>();
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            builder.RegisterType<SupMarkDbContext>().As<SupMarkDbContext>();

            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ListService>().As<IListService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ItemService>().As<IItemService>();

            //builder.RegisterType<ProductService>().As<IProductService>();
            //builder.RegisterType<ListService>().As<IListService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SupMark.API v1"));
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
