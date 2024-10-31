namespace EasyPizza.Contracts.Responses;

public sealed record OrderResponse
{
    public required Guid Id { get; init; }
    public required decimal Total { get; init; }
    public required DateTime OrderDate { get; init; }
    public required int OrderNumber { get; init; }
    public IEnumerable<PizzaResponse> Pizzas { get; init; } = [];
}

public sealed record PizzaResponse
{
    public required OrderPizzaBaseResponse PizzaBase { get; init; }
    public required decimal PizzaBasePrice { get; set; }
    public IEnumerable<PizzaIngredientResponse> PizzaIngredients { get; init; } = [];
}

public sealed record PizzaIngredientResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}

public sealed record OrderPizzaBaseResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Size { get; init; }
}