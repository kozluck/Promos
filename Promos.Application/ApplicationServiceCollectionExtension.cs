using Microsoft.Extensions.DependencyInjection;
using Promos.Application.Data;
using Promos.Application.Repositories;
using Promos.Application.Services;

namespace Promos.Application;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDbContext<PromotionsContext>();
        services.AddScoped<IPromotionRepository, PromotionRepository>();
        services.AddScoped<IPromotionService, PromotionService>();
        
        return services;
    }
}