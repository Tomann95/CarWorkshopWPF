using Microsoft.EntityFrameworkCore;
using CarWorkshopWPF.Models;

namespace CarWorkshopWPF.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CarWorkshop.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Cars)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}


