﻿namespace EasyPizza.API.Mapping;

public static class ContractMapping
{
    public static Ingredient MapToIngredient(this CreateIngredientRequest request)
    {
        return new Ingredient { Id = Guid.NewGuid(), Name = request.Name.ToLower(), Price = request.Price };
    }

    public static IngredientResponse MapToResponse(this Ingredient ingredient)
    {
        return new IngredientResponse
        {
            Id = ingredient.Id, Name = ingredient.Name, Price = ingredient.Price, Deleted = ingredient.Deleted
        };
    }

    public static IngredientsResponse MapToResponse(this IEnumerable<Ingredient> ingredients)
    {
        return new IngredientsResponse { Items = ingredients.Select(MapToResponse) };
    }

    public static Ingredient MapToIngredient(this UpdateIngredientRequest request, Guid id)
    {
        return new Ingredient
        {
            Id = id, Name = request.Name.ToLower(), Price = request.Price, Deleted = request.Deleted
        };
    }
}