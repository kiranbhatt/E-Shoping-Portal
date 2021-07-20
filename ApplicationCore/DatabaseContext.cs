using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data;
using DomainModels.Entities;

namespace ApplicationCore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityMapping();
        }
    }
}
