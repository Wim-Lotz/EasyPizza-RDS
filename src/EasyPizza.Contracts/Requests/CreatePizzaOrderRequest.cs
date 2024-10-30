namespace EasyPizza.Contracts.Requests;

public sealed record CreatePizzaOrderRequest
{
    public IEnumerable<PizzaRequest> Pizzas { get; init; } = [];
}

public sealed record PizzaRequest
{
    public required PizzaBaseRequest PizzaBase { get; init; }
    public IEnumerable<PizzaIngredientRequest> PizzaIngredients { get; init; } = [];
}

public sealed record PizzaBaseRequest
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Size { get; init; }
    public required decimal Price { get; init; }
}

public sealed record PizzaIngredientRequest
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}