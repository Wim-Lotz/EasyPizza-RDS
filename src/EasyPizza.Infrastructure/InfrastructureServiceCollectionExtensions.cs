﻿namespace EasyPizza.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddScoped<IPizzaBaseService, PizzaBaseService>();
        services.AddScoped<IPizzaOrderService, PizzaOrderService>();
        services.AddDbContext<EasyPizzaDbContext>();
        services.AddScoped<IEasyPizzaDbContext>(provider => provider.GetRequiredService<EasyPizzaDbContext>());

        return services;
    }
}