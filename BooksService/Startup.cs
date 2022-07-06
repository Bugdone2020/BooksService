using BooksDataAccesLayer;
using BooksDataAccesLayer.Interfaces;
using BooksDataAccesLayer.Repositories;
using BooksBuisnessLayer.Interfaces;
using BooksBuisnessLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using BooksBuisnessLayer.MapperProfiles;

namespace BooksPresentationLayer
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
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IBooksService, BooksService>();
            services.AddDbContext<EFCoreDbContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:Default"]));
            var assemblies = new[]
            {
                Assembly.GetAssembly(typeof(BooksProfile))
            };
            services.AddAutoMapper(assemblies);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
