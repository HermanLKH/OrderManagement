using Microsoft.EntityFrameworkCore;
using Orders.WebAPI.Entities;
using System.Diagnostics.Metrics;

namespace Orders.WebAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public ApplicationDbContext() { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(o => o.Order)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasIndex(nameof(Order.OrderNumber))
                .IsUnique();

            // seed data
            // orders
            string ordersJson = File.ReadAllText("orders.json");
            List<Order> orders = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(ordersJson)!;

            foreach (Order order in orders)
            {
                modelBuilder.Entity<Order>().HasData(order);
            }
            // order items
            string orderItemsJson = File.ReadAllText("orderItems.json");
            List<OrderItem> orderItems = System.Text.Json.JsonSerializer.Deserialize<List<OrderItem>>(orderItemsJson)!;

            foreach (OrderItem orderItem in orderItems)
            {
                modelBuilder.Entity<OrderItem>().HasData(orderItem);
            }
        }
    }
}
