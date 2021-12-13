using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wasted.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json.Serialization;
using Serilog;
using Wasted.API.Services;
using Microsoft.AspNetCore.Http;

namespace Wasted.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("logs/API_logs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            
            services.AddDbContext<WastedContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Wasted.API"),
                    b => b.MigrationsAssembly(typeof(WastedContext).Assembly.FullName)));
            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddScoped<IUserRepo, MockUserRepo>(); could be used to mock DB calls 
            services.AddScoped<IUserRepo, SqlUserRepo>();
            services.AddScoped<IProductRepo, SqlProductRepo>();
            services.AddScoped<IFridgeRepo, SqlFridgeRepo>();
            services.AddScoped<IIngredientRepo, SqlIngredientRepo>();
            services.AddScoped<IDishRepo, SqlDishRepo>();
            services.AddScoped<ITipRepo, SqlTipRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                app.UseHttpsRedirection(); 
                
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
