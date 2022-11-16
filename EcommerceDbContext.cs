using Microsoft.EntityFrameworkCore;

public class EcommerceDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public EcommerceDbContext()
    {
        if (!Products.Any())
        {
            Product iphone14 = new Product() { Name = "Iphone 14", Description = "un iphone molto bello", Price = 1499.99 };
            Product iphone13 = new Product() { Name = "Iphone 13", Description = "un iphone molto bello", Price = 1499.99 };
            Product samsungG = new Product() { Name = "Samsung Galaxy", Description = "un iphone molto bello", Price = 1499.99 };
            Product samsungA30 = new Product() { Name = "Samsung a30", Description = "un iphone molto bello", Price = 1499.99 };
            Product realmex3 = new Product() { Name = "Realme x3 super zoom", Description = "un iphone molto bello", Price = 1499.99 };
            Product realmeGT = new Product() { Name = "Realme GT", Description = "un iphone molto bello", Price = 1499.99 };
            Product redmi7 = new Product() { Name = "Xiaomi redmi note 7", Description = "un iphone molto bello", Price = 1499.99 };
            Product redmi8 = new Product() { Name = "Xiaomi redmi note 8", Description = "un iphone molto bello", Price = 1499.99 };
            Product honor70 = new Product() { Name = "Honor 70", Description = "un iphone molto bello", Price = 1499.99 };
            Product honorMagic4 = new Product() { Name = "Honor magic 4", Description = "un iphone molto bello", Price = 1499.99 };
            Products.Add(iphone14);
            Products.Add(iphone13);
            Products.Add(samsungG);
            Products.Add(samsungA30);
            Products.Add(realmex3);
            Products.Add(realmeGT);
            Products.Add(redmi7);
            Products.Add(redmi8);
            Products.Add(honor70);
            Products.Add(honorMagic4);

            SaveChanges();

        }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=csharp-ecommerce-db;Integrated Security=True;Encrypt=False");
    }

}