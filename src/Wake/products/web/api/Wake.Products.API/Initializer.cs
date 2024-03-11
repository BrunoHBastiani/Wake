using System.Text.Json.Serialization;

using Wake.Products.Application.Interfaces;
using Wake.Products.Application.Services;
using Wake.Products.Data;
using Wake.Products.Data.Interfaces;
using Wake.Products.Data.Repositories;

namespace Wake.Products.API;

public static class Initializer
{
    public static IServiceCollection AddApiInitializers(
        this IServiceCollection services)
    {
        services.AddScoped<WakeProductsContext>();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductRepository, ProductRepository>();

        //Apresenta os enums a partir de sua descrição no swagger
        services
            .AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.UseInlineDefinitionsForEnums();
        });


        return services;
    }
}
