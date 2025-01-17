namespace EasyPizza.Contracts.Requests;

public record GetAllIngredientsRequest
{
    public required string? Name { get; init; }
}