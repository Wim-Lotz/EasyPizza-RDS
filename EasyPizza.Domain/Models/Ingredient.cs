namespace EasyPizza.Domain.Models;

public class Ingredient
{
    public Ingredient(string name, decimal price)
    {
        Name = name.ToLower();
        Price = price;
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }

    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime UpdatedDate { get; set; }
}