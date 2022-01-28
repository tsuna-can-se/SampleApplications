using ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class ProductDbContext : DbContext
{
    public ProductDbContext()
    {
    }

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => this.Set<Product>();

    public DbSet<ProductCategory> ProductCategories => this.Set<ProductCategory>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder is null)
        {
            throw new ArgumentNullException(nameof(optionsBuilder));
        }

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Products;Integrated Security=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>(entity =>
        {
            // テーブル名の設定
            entity.ToTable("Products");

            // 主キーの設定
            entity.HasKey(product => product.ProductId);

            // 各カラムの制約条件、カラム名の設定
            entity.Property(product => product.Price)
            .HasColumnType("decimal(18,0)");
            entity.Property(product => product.ProductName)
                    .HasColumnName("Name")
                    .HasMaxLength(256)
                    .IsRequired();
            entity.Property(product => product.ProductDescription)
                .HasMaxLength(1024);
            entity.Property(product => product.Publisher)  // ★追加行
                .HasMaxLength(256);

            // 外部キー制約の設定
            entity.HasOne(product => product.ProductCategory)
                .WithMany(productCategory => productCategory.Products)
                .HasForeignKey(product => product.ProcuctCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductCategories");

            // 行バージョンカラムの設定
            entity.Property(product => product.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();

            // マスターデータの登録（Publisher の値を追加設定）
            entity.HasData(new Product { ProductId = 1, ProductName = "C#の本", ProcuctCategoryId = 1, Price = 2000, Publisher = "DOTNET" });
            entity.HasData(new Product { ProductId = 2, ProductName = "Visual Studioの本", ProcuctCategoryId = 1, Price = 2200, Publisher = "DOTNET" });
            entity.HasData(new Product { ProductId = 3, ProductName = ".NETの本", ProcuctCategoryId = 1, Price = 2500, Publisher = "DOTNET" });
            entity.HasData(new Product { ProductId = 4, ProductName = "冷蔵庫", ProcuctCategoryId = 2, Price = 150000, Publisher = "HUTABISHI" });
            entity.HasData(new Product { ProductId = 5, ProductName = "トランプ", ProcuctCategoryId = 3, Price = 280, Publisher = "HONTENDO" });
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            // テーブル名の設定
            entity.ToTable("ProductCategories");

            // 主キーの設定
            entity.HasKey(productCategory => productCategory.ProductCategoryId);

            // 各カラムの制約条件、カラム名の設定
            entity.Property(productCategory => productCategory.Name)
            .HasMaxLength(256)
            .IsRequired();

            // 行バージョンカラムの設定
            entity.Property(Product => Product.RowVersion)
            .IsRequired()
            .IsRowVersion()
            .IsConcurrencyToken();

            // マスターデータの登録
            entity.HasData(new ProductCategory { ProductCategoryId = 1, Name = "本" });
            entity.HasData(new ProductCategory { ProductCategoryId = 2, Name = "家電" });
            entity.HasData(new ProductCategory { ProductCategoryId = 3, Name = "おもちゃ" });
        });
    }
}
