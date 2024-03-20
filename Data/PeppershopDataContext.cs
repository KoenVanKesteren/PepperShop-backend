using Microsoft.EntityFrameworkCore;
using PepperShop.Models;

namespace PepperShop.Data;

public class PeppershopDataContext : DbContext
{
    public PeppershopDataContext(DbContextOptions<PeppershopDataContext> options)
        : base(options)
    {
    }

    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<ProductCategoryProduct> ProductCategorieProducts { get; set; } = null!;

    public DbSet<ProductDetail> ProductDetails { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategoryProduct>()
            .HasKey(m => new { m.ProductCategoryId, m.ProductId });
    }
}



