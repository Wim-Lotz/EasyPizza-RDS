namespace EasyPizza.Application.Commands;

public sealed record CreateIngredientCommand(Ingredient Ingredient) : IRequest { }