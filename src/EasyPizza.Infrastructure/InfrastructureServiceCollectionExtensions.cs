namespace EasyPizza.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddDbContext<EasyPizzaDbContext>();
        services.AddScoped<IEasyPizzaDbContext>(provider => provider.GetRequiredService<EasyPizzaDbContext>());

        return services;
    }
}