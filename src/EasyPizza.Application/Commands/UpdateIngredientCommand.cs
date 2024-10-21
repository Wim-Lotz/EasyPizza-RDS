namespace EasyPizza.Application.Commands;

public sealed record UpdateIngredientCommand(Ingredient Ingredient) : IRequest<bool>;