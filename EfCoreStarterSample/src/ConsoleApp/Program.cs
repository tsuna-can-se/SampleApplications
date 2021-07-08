using System;
using ApplicationCore.Repositories;
using Infrastructure.Ef;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using ProductDbContext context = new ProductDbContext();
            IProductRepository repository = new ProductRepository(context);

            var categoryies = repository.GetAllCategories();
            foreach (var category in categoryies)
            {
                var products = repository.GetProducts(category);
                Console.WriteLine($"{category.Name}:{products.Count}");
            }
        }
    }
}
