namespace EasyPizza.Contracts.Requests;

public record GetAllIngredientsRequest
{
    public required string? Name { get; init; }
    public required string? SortBy { get; init; }
}