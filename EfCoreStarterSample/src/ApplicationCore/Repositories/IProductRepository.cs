using System.Collections.Generic;
using ApplicationCore.Entity;

namespace ApplicationCore.Repositories
{
    public interface IProductRepository
    {
        IList<ProductCategory> GetAllCategories();
        IList<Product> GetProducts(ProductCategory productCategory);
    }
}
