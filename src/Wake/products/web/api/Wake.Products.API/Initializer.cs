using Wake.Products.Application.Interfaces;
using Wake.Products.Application.Services;
using Wake.Products.Data.Interfaces;
using Wake.Products.Data.Repositories;

namespace Wake.Products.API;

public static class Initializer
{
    public static IServiceCollection AddApiInitializers(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
