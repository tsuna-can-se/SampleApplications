namespace ApplicationCore.Entity;

public class ProductCategory
{
    public long ProductCategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public byte[] RowVersion { get; set; } = Array.Empty<byte>();

    public IList<Product> Products { get; set; } = new List<Product>();
}
