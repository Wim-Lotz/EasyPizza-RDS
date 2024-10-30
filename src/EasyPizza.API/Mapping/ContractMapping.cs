using System.Security.Cryptography.X509Certificates;

using EasyPizza.Domain.Enums;

namespace EasyPizza.API.Mapping;

public static class ContractMapping
{
    public static Ingredient MapToIngredient(this CreateIngredientRequest request)
    {
        return new Ingredient
        {
            Id = Guid.NewGuid(), 
            Name = request.Name.ToLower(), 
            Price = request.Price
        };
    }

    public static IngredientResponse MapToResponse(this Ingredient ingredient)
    {
        return new IngredientResponse
        {
            Id = ingredient.Id, 
            Name = ingredient.Name, 
            Price = ingredient.Price, 
            Deleted = ingredient.Deleted
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
            Id = id, 
            Name = request.Name.ToLower(), 
            Price = request.Price, 
            Deleted = request.Deleted
        };
    }
    
    public static PizzaBaseResponse MapToResponse(this PizzaBase pizzaBase)
    {
        return new PizzaBaseResponse
        {
            Id = pizzaBase.Id, 
            Name = pizzaBase.Name, 
            Price = pizzaBase.Price, 
            Size = pizzaBase.PizzaBaseSize.ToString(),
            Deleted = pizzaBase.Deleted
        };
    }

    public static PizzaBasesResponse MapToResponse(this IEnumerable<PizzaBase> ingredients)
    {
        return new PizzaBasesResponse { Items = ingredients.Select(MapToResponse) };
    }

    public static PizzaBase? MapToBase(this CreatePizzaBaseRequest request)
    {
        if(!Enum.TryParse(typeof(PizzaBaseSize), request.Size, ignoreCase: true, out var size))
            return null;
        
        return new PizzaBase
        {
            Id = Guid.NewGuid(),
            Name = request.Name.ToLower(),
            PizzaBaseSize = (PizzaBaseSize)size,
            Price = request.Price
        };
    }

    public static PizzaBase? MapToBase(this UpdatePizzaBaseRequest request, Guid id)
    {
        if(!Enum.TryParse(typeof(PizzaBaseSize), request.Size, ignoreCase: true, out var size))
            return null;
        
        return new PizzaBase
        {
            Id = id,
            Name = request.Name.ToLower(),
            PizzaBaseSize = (PizzaBaseSize)size,
            Price = request.Price,
            Deleted = request.Deleted
        };
    }

    public static (Order?, List<Pizza>) MapToPizzaOrder(this CreatePizzaOrderRequest request)
    {
        var newOrder = new Order
        {
            Id = Guid.NewGuid(),
            Total = GetTotal(request),
            OrderDate = DateTime.UtcNow,
            OrderNumber = 1,
            OrderLines = []
        };
        
        var pizzas = new List<Pizza>();
        
        foreach (var pizza in request.Pizzas)
        {
            if (!Enum.TryParse(typeof(PizzaBaseSize), pizza.PizzaBase.Size, ignoreCase: true, out var size))
                return (null, []);
            
            var pizzaBase = new PizzaBase
            {
                Id = pizza.PizzaBase.Id,
                Name = pizza.PizzaBase.Name,
                Price = pizza.PizzaBase.Price,
                PizzaBaseSize = (PizzaBaseSize)size
            };

            var newPizza = new Pizza
            {
                Id = Guid.NewGuid(),
                PizzaBaseId = pizzaBase.Id,
                PizzaBasePrice = pizzaBase.Price,
                PizzaIngredients = [],
                OrderLines = []
            };

            var newOrderLine = new OrderLine
            {
                Id = Guid.NewGuid(), 
                OrderId = newOrder.Id, 
                PizzaId = newPizza.Id
            };
            
            newOrder.OrderLines.Add(newOrderLine);
            newPizza.OrderLines.Add(newOrderLine);
            
            foreach (var pizzaIngredient in pizza.PizzaIngredients)
            {
                newPizza.PizzaIngredients.Add(new PizzaIngredient
                {
                    Id = Guid.NewGuid(),
                    IngredientPrice = pizzaIngredient.Price,
                    IngredientId = pizzaIngredient.Id,
                    PizzaId = newPizza.Id
                });
            }
            
            pizzas.Add(newPizza);
        }
        
        return (newOrder, pizzas);
    }

    private static decimal GetTotal(CreatePizzaOrderRequest request)
    {
        decimal total = 0M;
        foreach (var p in request.Pizzas)
        {
            total += p.PizzaBase.Price;
            total += p.PizzaIngredients.Sum(i => i.Price);
        }

        return total;
    }
}