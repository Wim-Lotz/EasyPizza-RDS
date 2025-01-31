namespace EasyPizza.Contracts.Requests.V1;

public record struct CreateOrderRequest
{
    public IEnumerable<PizzaRequest> Pizzas { get; init; }
}

public record struct PizzaRequest
{
    public required PizzaBaseRequest PizzaBase { get; init; }
    public IEnumerable<PizzaIngredientRequest> PizzaIngredients { get; init; }
}

public record struct PizzaBaseRequest
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Size { get; init; }
    public required decimal Price { get; init; }
}

public record struct PizzaIngredientRequest
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}