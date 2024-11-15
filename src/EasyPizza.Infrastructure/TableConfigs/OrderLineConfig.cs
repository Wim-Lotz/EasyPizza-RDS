namespace EasyPizza.Infrastructure.TableConfigs;

public class OrderLineConfig : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(e => e.Pizza)
            .WithOne(e => e.OrderLine)
            .HasForeignKey<OrderLine>(e => e.PizzaId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.Order)
            .WithMany(e => e.OrderLines)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}