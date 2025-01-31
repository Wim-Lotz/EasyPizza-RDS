using System.Security.Cryptography.X509Certificates;

using EasyPizza.Contracts.Requests.V1;
using EasyPizza.Contracts.Responses.V1;
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

    public static OrdersResponse MapToResponse(this IEnumerable<Order> orders, int page, int pageSize, int ordersCount)
    {
        return new OrdersResponse
        {
            Items = orders.Select(MapToResponse),
            Page = page,
            PageSize = pageSize,
            Total = ordersCount
        };
    }
    public static OrderResponse MapToResponse(this Order request)
    {
        var pizzaResponseList = new List<PizzaResponse>();
        
        foreach (OrderLine orderLine in request.OrderLines)
        {
            var ingredients = new List<PizzaIngredientResponse>();
            foreach (var pizzaIngredient in orderLine.Pizza.PizzaIngredients)
            {
                ingredients.Add(new PizzaIngredientResponse
                {
                    Id = pizzaIngredient.Id,
                    Name = pizzaIngredient.Ingredient.Name,
                    Price = pizzaIngredient.IngredientPrice
                });
            }
            
            pizzaResponseList.Add(new PizzaResponse
            {
                PizzaBasePrice = orderLine.Pizza.PizzaBasePrice,
                PizzaBase = new OrderPizzaBaseResponse
                {
                    Id = orderLine.Pizza.PizzaBase.Id,
                    Name = orderLine.Pizza.PizzaBase.Name,
                    Size = orderLine.Pizza.PizzaBase.PizzaBaseSize.ToString(),
                },
                PizzaIngredients = ingredients
            });
        }
        
        return new OrderResponse
        {
            Id = request.Id,
            Total = request.Total,
            OrderDate = request.OrderDate,
            OrderNumber = request.OrderNumber,
            Pizzas = pizzaResponseList
        };
    }
    
    public static Order MapToOrder(this CreateOrderRequest request)
    {
        Order newOrder = CreateOrder(request);

        foreach (var pizza in request.Pizzas)
        {
            var newPizzaId = Guid.NewGuid();
            var newOrderLineId = Guid.NewGuid();
            var pizzaIngredients = pizza.PizzaIngredients.Select(ingredient => new PizzaIngredient
            {
                Id = Guid.NewGuid(), 
                IngredientPrice = ingredient.Price, 
                IngredientId = ingredient.Id, 
                PizzaId = newPizzaId
            }).ToList();

            var newPizza = new Pizza
            {
                Id = newPizzaId,
                PizzaBasePrice = pizza.PizzaBase.Price,
                PizzaBaseId = pizza.PizzaBase.Id,
                PizzaIngredients = pizzaIngredients
            };

            var newOrderLine = new OrderLine
            {
                Id = newOrderLineId, 
                OrderId = newOrder.Id, 
                PizzaId = newPizzaId, 
                Pizza = newPizza
            };

            newOrder.OrderLines.Add(newOrderLine);
        }
        return newOrder;
    }
    
    private static Order CreateOrder(CreateOrderRequest request)
    {
        var newOrder = new Order
        {
            Id = Guid.NewGuid(),
            Total = GetTotal(request),
            OrderDate = DateTime.UtcNow,
            OrderNumber = 1,
            OrderLines = []
        };
        return newOrder;
    }

    private static decimal GetTotal(CreateOrderRequest request)
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

public class MappingError
{
    public IList<string> Errors { get; init; } = [];
}