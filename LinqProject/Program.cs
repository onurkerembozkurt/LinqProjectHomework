using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>()
            {
                new Category{CategoryId=1, CategoryName="Bilgisayar" },
                new Category{CategoryId=2,CategoryName="Telefon"},
            };
            List<Product> products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Acer Laptop",QuantityPerUnit="32 GB Ram ",UnitsInStock=5, UnitPrice=10000},
                new Product{ProductId=2,CategoryId=1,ProductName="Asus Laptop",QuantityPerUnit="16 GB Ram ",UnitsInStock=3, UnitPrice=8000},
                new Product{ProductId=3,CategoryId=1,ProductName="Hp Laptop",QuantityPerUnit="8 GB Ram ",UnitsInStock=2, UnitPrice=6000},
                new Product{ProductId=4,CategoryId=2,ProductName="Samsung Telefon",QuantityPerUnit="4 GB Ram ",UnitsInStock=15, UnitPrice=5000},
                new Product{ProductId=5,CategoryId=2,ProductName="Apple Telefon",QuantityPerUnit="4 GB Ram ",UnitsInStock=0, UnitPrice=8000}

            };
            //Algoritmik
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                    Console.WriteLine(product.ProductName);
            }

            //Linq

            var result = products.Where(p=>p.UnitPrice>5000&&p.UnitsInStock>3);

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
            GetProducts(products);
        }
        static List<Product> GetProducts(List<Product> products)
        {
            List<Product> filteredProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    filteredProducts.Add(product);
                }
                   
            }
            return filteredProducts;
        }
        static List<Product> GetProductsLinq(List<Product> products)
        {
           return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();
        }
    }
   
}
