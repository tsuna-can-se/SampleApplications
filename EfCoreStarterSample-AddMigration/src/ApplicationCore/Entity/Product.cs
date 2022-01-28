namespace ApplicationCore.Entity;

public class Product
{
    private ProductCategory? productCategory;

    public long ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string? ProductDescription { get; set; }

    public decimal? Price { get; set; }

    public string? Publisher { get; set; }  // ★追加行

    public long ProcuctCategoryId { get; set; }

    public byte[] RowVersion { get; set; } = Array.Empty<byte>();

    public ProductCategory ProductCategory
    {
        get => this.productCategory ?? throw new InvalidOperationException("Uninitialized property: " + nameof(ProductCategory));
        set => this.productCategory = value;
    }
}
