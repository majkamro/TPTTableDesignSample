using Microsoft.EntityFrameworkCore;
using TPTTableDesignSample.Models;

namespace TPTTableDesignSample.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Party> Parties { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Party>().ToTable("Parties");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");

            modelBuilder.Entity<Customer>().HasBaseType<Party>();
            modelBuilder.Entity<Supplier>().HasBaseType<Party>();
        }
    }
}
