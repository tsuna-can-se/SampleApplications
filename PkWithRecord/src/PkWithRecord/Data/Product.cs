using System.ComponentModel.DataAnnotations.Schema;

namespace PkWithRecord.Data;

public class Product
{
    public ProductId Id { get; set; }

    public required string Name { get; set; }

    public decimal Price { get; set; }
}
