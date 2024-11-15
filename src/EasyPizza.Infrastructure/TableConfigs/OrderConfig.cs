namespace EasyPizza.Infrastructure.TableConfigs;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Total).IsRequired();
        builder.Property(p => p.OrderDate).IsRequired();
        builder.Property(p => p.OrderNumber).IsRequired();

        builder.HasMany(e => e.OrderLines)
            .WithOne(e => e.Order)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}