using PkWithRecord.Data;
using Microsoft.EntityFrameworkCore;

using (var context1 = new ProductDbContext())
{
    // データベースを初期化
    context1.Database.EnsureDeleted();
    context1.Database.EnsureCreated();
}

Console.WriteLine("==データ追加=================");

var id1 = new ProductId(Guid.NewGuid());
var id2 = new ProductId(Guid.NewGuid());
var id3 = new ProductId(Guid.NewGuid());

using (var context2 = new ProductDbContext())
{
    // データを3件追加し、追加したデータを表示
    context2.Products.Add(new Product { Id = id1, Name = "Apple", Price = 100 });
    context2.Products.Add(new Product { Id = id2, Name = "Banana", Price = 200 });
    context2.Products.Add(new Product { Id = id3, Name = "Cherry", Price = 300 });
    await context2.SaveChangesAsync();
    foreach (var product in context2.Products)
    {
        Console.WriteLine($"{product.Id}: {product.Name} {product.Price}");
    }
}

Console.WriteLine("==データ1件取得=================");

using (var context3 = new ProductDbContext())
{
    // データを1件取得し、取得したデータを表示
    var product = await context3.Products.FindAsync(id2);
    Console.WriteLine($"{product?.Id}: {product?.Name} {product?.Price}");
}

Console.WriteLine("==データ更新=================");

using (var context4 = new ProductDbContext())
{
    // データを1件更新し、更新したデータを表示
    var product = await context4.Products.Where(p => p.Id == id3).FirstAsync();
    Console.WriteLine($"{product.Id}: {product.Name} {product.Price}");
    product.Price = 450;
    await context4.SaveChangesAsync();
}

Console.WriteLine("==データ削除=================");

using (var context5 = new ProductDbContext())
{
    // データを1件削除し、削除したデータを表示
    var product = await context5.Products.Where(p => p.Id == id1).FirstAsync();
    Console.WriteLine($"{product.Id}: {product.Name} {product.Price}");
    context5.Products.Remove(product);
    await context5.SaveChangesAsync();
}

Console.WriteLine("==全件取得=================");

using (var context6 = new ProductDbContext())
{
    // データを全件取得し、取得したデータを表示
    foreach (var product in context6.Products)
    {
        Console.WriteLine($"{product.Id}: {product.Name} {product.Price}");
    }
}