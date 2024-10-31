namespace EasyPizza.Infrastructure.TableConfigs;

public class PizzaConfig
{
    public PizzaConfig(EntityTypeBuilder<Pizza> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(p => p.Id);
     
        entityTypeBuilder.Property(p => p.PizzaBasePrice).IsRequired();
        
        entityTypeBuilder.HasMany(e => e.PizzaIngredients)
            .WithOne(e => e.Pizza)
            .HasForeignKey(e => e.PizzaId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        entityTypeBuilder.HasOne(e => e.PizzaBase)
            .WithMany(e => e.Pizzas)
            .HasForeignKey(e => e.PizzaBaseId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        
        entityTypeBuilder.HasOne(e => e.OrderLine)
            .WithOne(e => e.Pizza)
            .HasForeignKey<OrderLine>(e => e.PizzaId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}