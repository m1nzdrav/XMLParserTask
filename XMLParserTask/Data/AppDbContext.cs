using Microsoft.EntityFrameworkCore;
using XMLParserTask.Model;

namespace XMLParserTask.Data;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    public DbSet<Products> Products { get; set; }

    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public DbSet<Users> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=Shopper;",
            new MySqlServerVersion(new Version(8, 3, 0)));
    }
}