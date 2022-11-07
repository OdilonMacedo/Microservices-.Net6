using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Name",
                Price = new decimal(69.9),
                Description = "Description",
                ImageURL = "",
                CategoryName = "Skirt"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Caruzo's hair",
                Price = new decimal(0.0),
                Description = "Actually free, nobody want's that shit",
                ImageURL = "Caruzo Likes it",
                CategoryName = "Sausage Hair"
            });
        }
    }
}
