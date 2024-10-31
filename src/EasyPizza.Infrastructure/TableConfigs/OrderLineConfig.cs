namespace EasyPizza.Infrastructure.TableConfigs;

public class OrderLineConfig
{
    public OrderLineConfig(EntityTypeBuilder<OrderLine> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(p => p.Id);

        entityTypeBuilder.HasOne(e => e.Pizza)
            .WithOne(e => e.OrderLine)
            .HasForeignKey<OrderLine>(e => e.PizzaId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        
        entityTypeBuilder.HasOne(e => e.Order)
            .WithMany(e => e.OrderLines)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}