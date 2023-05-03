using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Product> productList = new List<Product>();
        SeedData(productList);

       
        var productsInRange = from p in productList where p.Price >= 20000 && p.Price <= 40000 select p.ProductName;

        Console.WriteLine("Products with price between 20000 to 40000:");
        foreach (var product in productsInRange)
        {
            Console.WriteLine(product);
        }

        
        var productsWithLetterA = from p in productList where p.ProductName.Contains("a") select p;

        Console.WriteLine("\nProducts with name containing letter a:");
        foreach (var product in productsWithLetterA)
        {
            Console.WriteLine($"{product.ProductId} {product.ProductName} {product.Brand} {product.Quantity} {product.Price}");
        }

        
        var productsInAlphabeticalOrder = from p in productList orderby p.ProductName select p;

        Console.WriteLine("\nProducts in alphabetical order:");
        foreach (var product in productsInAlphabeticalOrder)
        {
            Console.WriteLine($"{product.ProductId} {product.ProductName} {product.Brand} {product.Quantity} {product.Price}");
        }

        
        var highestPrice = productList.Max(p => p.Price);
        Console.WriteLine($"\nHighest Price: {highestPrice}");

        
        var productExists = productList.Any(p => p.ProductId == "P003");
        Console.WriteLine($"\nProduct with ProductId P003 exists: {productExists}");
    }

    static void SeedData(List<Product> productList)
    {
        productList.Add(new Product { ProductId = "P001", ProductName = "Laptop", Brand = "Dell", Quantity = 5, Price = 35000 });
        productList.Add(new Product { ProductId = "P002", ProductName = "Camera", Brand = "Canon", Quantity = 8, Price = 28500 });
        productList.Add(new Product { ProductId = "P003", ProductName = "Tablet", Brand = "Lenovo", Quantity = 4, Price = 15000 });
        productList.Add(new Product { ProductId = "P004", ProductName = "Mobile", Brand = "Apple", Quantity = 9, Price = 65000 });
        productList.Add(new Product { ProductId = "P005", ProductName = "Earphones", Brand = "Boat", Quantity = 2, Price = 1500 });
    }
}

class Product
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string Brand { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
