using System.Collections.Generic;

namespace ApplicationCore.Entity
{
    public class ProductCategory
    {
        public long ProductCategoryId { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
        public IList<Product> Products { get; set; }
    }
}
