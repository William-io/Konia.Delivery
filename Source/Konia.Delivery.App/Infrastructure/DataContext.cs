using Flunt.Notifications;
using Konia.Delivery.App.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Konia.Delivery.App.Infrastructure;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Numero da entrega é requirido. 
        builder.Entity<Order>()
            .Property(p => p.Number).IsRequired();

        builder.Ignore<Notification>();
    }


    public DbSet<Order> Orders { get; set; }

}