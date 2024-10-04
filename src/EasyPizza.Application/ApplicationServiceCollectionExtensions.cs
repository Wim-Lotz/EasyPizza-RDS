using EasyPizza.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EasyPizza.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IEasyPizzaRepository, EasyPizzaRepository>();
        return services;
    }
}