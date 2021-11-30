using Microsoft.EntityFrameworkCore;

namespace ChangeTrackerConfirm.Models;

public class SampleDbContext : DbContext
{
    public SampleDbContext() { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ArgumentNullException.ThrowIfNull(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SampleDatabase;Integrated Security=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name)
                .HasColumnName("Name")
                .HasMaxLength(128)
                .IsRequired();
            entity.HasData(new Category[]
            {
                new() { Id = 1, Name = "本" },
                new() { Id = 2, Name = "おもちゃ" },
                new() { Id = 3, Name = "PC・周辺機器" },
            });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(256)
                .IsRequired();
            entity.Property(p => p.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(18,0)")
                .IsRequired();
            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasData(new Product[]
            {
                new() { Id = 1, CategoryId = 1, Price = 2000, Name = "C#の本" },
                new() { Id = 2, CategoryId = 1, Price = 1800, Name = "F#の本" },
                new() { Id = 3, CategoryId = 2, Price = 3500, Name = "つみき" },
                new() { Id = 4, CategoryId = 2, Price = 2000, Name = "わなげ" },
                new() { Id = 5, CategoryId = 2, Price = 500, Name = "トランプ" },
                new() { Id = 6, CategoryId = 3, Price = 50000, Name = "ラップトップパソコン" },
                new() { Id = 7, CategoryId = 3, Price = 85000, Name = "モバイルノートパソコン" },
                new() { Id = 8, CategoryId = 3, Price = 120000, Name = "デスクトップパソコン" },
                new() { Id = 9, CategoryId = 3, Price = 3000, Name = "マウス" },
                new() { Id = 10, CategoryId = 3, Price = 5000, Name = "キーボード" },
                new() { Id = 11, CategoryId = 3, Price = 20000, Name = "モニター" },
            });
        });
    }
}
