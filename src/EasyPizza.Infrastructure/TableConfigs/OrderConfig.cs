namespace EasyPizza.Infrastructure.TableConfigs;

public class OrderConfig
{
    public OrderConfig(EntityTypeBuilder<Order> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(p => p.Id);
        
        entityTypeBuilder.Property(p => p.Total).IsRequired();
        entityTypeBuilder.Property(p => p.OrderDate).IsRequired();
        entityTypeBuilder.Property(p => p.OrderNumber).IsRequired();

        entityTypeBuilder.HasMany(e => e.OrderLines)
            .WithOne(e => e.Order)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}