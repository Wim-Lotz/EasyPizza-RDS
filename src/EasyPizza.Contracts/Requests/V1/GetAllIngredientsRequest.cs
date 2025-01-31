namespace EasyPizza.Contracts.Requests.V1;

public record GetAllIngredientsRequest
{
    public required string? Name { get; init; }
    public required string? SortBy { get; init; }
}