namespace ChangeTrackerConfirm.Models;

public class Product
{
    public Product() => this.Name = string.Empty;

    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    public Category? Category { get; set; }
}
