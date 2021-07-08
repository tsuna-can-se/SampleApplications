namespace ApplicationCore.Entity
{
    public class Product
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public long ProcuctCategoryId { get; set; }
        public byte[] RowVersion { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
