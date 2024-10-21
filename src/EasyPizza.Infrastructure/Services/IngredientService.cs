﻿namespace EasyPizza.Infrastructure.Services;

public class IngredientService : IIngredientService
{
    private readonly IEasyPizzaDbContext _context;

    public IngredientService(IEasyPizzaDbContext context)
    {
        _context = context;
    }

    public async Task<Ingredient> GetIngredients()
    {
        // {
        //     //return await _context.Ingredients.Select(i => new IngredientsResponse{Id = i.Id, i.Name, i.Price}).ToListAsync();
        //     var ingredients = await _context.Ingredients.ToListAsync();
        //
        //     // var ingredientsResponse = new IngredientsResponse
        //     // {
        //     //     Items = ingredients.Select(ingredient => 
        //     //         new IngredientResponse { Id = ingredient.Id, Name = ingredient.Name, Price = ingredient.Price }
        //     //     )
        //     // };
        //     return ingredientsResponse;
        throw new NotImplementedException();
    }

    public async Task CreateIngredient(Ingredient ingredient, CancellationToken cancellationToken)
    {
        await _context.Ingredients.AddAsync(ingredient, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public bool DoesIngredientExist(string name, CancellationToken cancellationToken)
    {
        return _context.Ingredients.Any(i => i.Name.ToLower() == name.ToLower());
    }

}