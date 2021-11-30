namespace ChangeTrackerConfirm.Models;

public class Category
{
    public Category()
    {
        this.Name = string.Empty;
        this.Products = new HashSet<Product>();
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
