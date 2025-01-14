namespace PkWithRecord.Data;

public record struct ProductId
{
    public ProductId(Guid value)
        => this.Value = value;

    public Guid Value { get; }
}
