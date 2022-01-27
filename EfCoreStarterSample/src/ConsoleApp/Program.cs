using ApplicationCore.Repositories;
using Infrastructure.Ef;

using ProductDbContext context = new();
IProductRepository repository = new ProductRepository(context);

var categoryies = repository.GetAllCategories();
foreach (var category in categoryies)
{
    var products = repository.GetProducts(category);
    Console.WriteLine($"{category.Name}:{products.Count}");
}
