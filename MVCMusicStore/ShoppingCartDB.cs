using System.Data.Entity;
using MVCMusicStore.Models;

namespace MVCMusicStore
{
    public class ShoppingCartDB : DbContext
    {
        public ShoppingCartDB() : base("name=ShoppingCartDB"){ }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}