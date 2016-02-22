using System.Data.Entity;

namespace GamesStore.Models.Repository
{

    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<Customer> Customers { get; set; }

    }

}