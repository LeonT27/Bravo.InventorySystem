using System.Reflection;
using Application.Services.ProductService;
using Application.Services.UnitService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUnitService, UnitService>();

            return services;
        }
    }
}
