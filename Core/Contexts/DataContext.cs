using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }

    public class DataContextMigration : DataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Post12345";
            optionsBuilder.UseNpgsql(connection);
        }
    }
}