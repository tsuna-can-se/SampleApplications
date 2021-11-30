using ChangeTrackerConfirm.Models;

using var dbContext = new SampleDbContext();
ShowChangeTracker(1, dbContext);

var products = dbContext.Products
    .Where(p => p.CategoryId == 1)
    .ToList();
ShowChangeTracker(2, dbContext);

foreach (var product in products)
{
    product.Price = product.Price * 1.1M;
}

ShowChangeTracker(3, dbContext);

var newProduct = new Product
{
    Name = "Entity Framework の本",
    Price = 2800,
    CategoryId = 1,
};
dbContext.Products.Add(newProduct);
ShowChangeTracker(4, dbContext);

dbContext.SaveChanges();
ShowChangeTracker(5, dbContext);

void ShowChangeTracker(int count, SampleDbContext dbContext)
{
    Console.WriteLine($"= No.{count} ======================");
    Console.WriteLine(dbContext.ChangeTracker.DebugView.ShortView);
    Console.WriteLine("=============================");
}
