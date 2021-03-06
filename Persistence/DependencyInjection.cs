using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ModelDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ModelDb")));

            services.AddScoped<IModel>(provider => provider.GetService<ModelDbContext>());

            return services;
        }
    }
}
