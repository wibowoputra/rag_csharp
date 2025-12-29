using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Infrastructure.Persistence
{
	public class AppDbContext : DbContext
	{
		public DbSet<Order> Orders => Set<Order>();

		public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(b =>
            {
                b.HasKey(x => x.Id);

                // Konfigurasi backing field
                b.Navigation(x => x.Items)
                    .UsePropertyAccessMode(PropertyAccessMode.Field);

                b.OwnsMany(x => x.Items, items =>
                {
                    items.WithOwner().HasForeignKey("OrderId");

                    items.Property<Guid>("Id");
                    items.HasKey("Id");

                    items.Property(x => x.ProductName).IsRequired();
                    items.Property(x => x.Price);
                    items.Property(x => x.Quantity);

                    items.ToTable("OrderItems");
                });
            });
        }
    }
}
