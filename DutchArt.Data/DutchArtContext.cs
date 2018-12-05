using DutchArt.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DutchArt.Data
{
    public class DutchArtContext : IdentityDbContext<DutchArtUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Art> Arts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DutchArtContext()
        {

        }
        public DutchArtContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DutchArtDB;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
