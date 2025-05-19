using FirstApi.Products.Entity;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Data;

public class AppDbContext: DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=OrderManagementDB.sqlite");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging(); /*Usado para ver parametros*/
        
        base.OnConfiguring(optionsBuilder);
    }
}