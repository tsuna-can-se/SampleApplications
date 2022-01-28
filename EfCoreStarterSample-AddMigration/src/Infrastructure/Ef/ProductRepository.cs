using ApplicationCore.Entity;
using ApplicationCore.Repositories;

namespace Infrastructure.Ef;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext context;

    public ProductRepository(ProductDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IList<ProductCategory> GetAllCategories()
    {
        return this.context.ProductCategories.ToList();
    }

    public IList<Product> GetProducts(ProductCategory productCategory)
    {
        if (productCategory is null)
        {
            throw new ArgumentNullException(nameof(productCategory));
        }

        return this.context.Products
            .Where(p => p.ProcuctCategoryId == productCategory.ProductCategoryId)
            .ToList();
    }
}
