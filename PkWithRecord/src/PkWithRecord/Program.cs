using PkWithRecord.Data;

using var context = new ProductDbContext();
context.Products.Add(new Product { Name = "Apple", Price = 100 });
context.Products.Add(new Product { Name = "Banana", Price = 200 });
context.Products.Add(new Product { Name = "Cherry", Price = 300 });
context.SaveChanges();
