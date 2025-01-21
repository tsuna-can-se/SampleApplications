using Microsoft.EntityFrameworkCore;

namespace PkWithRecord.Data;

internal class ProductDbContext : DbContext
{
    public ProductDbContext()
    {
    }

    public ProductDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>(product =>
        {
            product.Property(p => p.Id)
                .HasConversion(
                    id => id.Value,
                    value => new ProductId(value));
            product.Property(p => p.Price)
                .HasColumnType("decimal(18, 0)");
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ArgumentNullException.ThrowIfNull(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PkWithRecord;Integrated Security=True");
        }
    }
}
