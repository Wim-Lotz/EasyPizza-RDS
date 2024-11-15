namespace EasyPizza.Infrastructure.TableConfigs;

public class IngredientConfig : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();

        builder.Property(p => p.Name).HasMaxLength(20);
        builder.Property(a => a.Name).IsRequired();

        builder.Property(a => a.Price).IsRequired();

        builder.HasMany(e => e.PizzaIngredients)
            .WithOne(e => e.Ingredient)
            .HasForeignKey(e => e.IngredientId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasData(
            new Ingredient { Id = Guid.NewGuid(), Name = "cheese", Price = 1.25M },
            new Ingredient { Id = Guid.NewGuid(), Name = "salami", Price = 2.0M },
            new Ingredient { Id = Guid.NewGuid(), Name = "green pepper", Price = 0.25M });
    }
}