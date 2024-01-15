using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tourism.Application.Abstraction;

namespace Tourism.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
         //   string connectionsString = "Server=DESKTOP-HUHB6EP;Database=TouristDb;Trusted_Connection=True;TrustServerCertificate=True;";
            services.AddDbContext<ITourismDbContext, TourismDbContext>(options =>
             {
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
             });

            return services;
        }
    }
}