using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PmAPI.Data;
using PmAPI.Interfaces;
using PmAPI.Services;

namespace PmAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
         public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddScoped<ITicketService,TicketService>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSignalR();

            // Add ReferenceHandler.Preserve to JsonSerializerOptions
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

                    //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });
            


            return services;
        }
    }
}