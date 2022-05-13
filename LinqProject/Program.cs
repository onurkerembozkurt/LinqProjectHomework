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
            //TestMethod(products);
            //-----------------------
            //Linq'Methods
            /*Single line queary
             * FindMethod(products);
             AnyMethod(products);
             FindAllMethod(products);
             WhereOrderByAsc(products);
             AscAscWhereOrderby(products);
             ClassicLinqTest(products);
            */
            var result = from p in products
                         join c in categories
                         on p.CategoryId equals c.CategoryId
                         where p.UnitPrice>5000
                         orderby p.UnitPrice descending
      select new ProductDto {ProductId=p.ProductId,CategoryName=c.CategoryName,ProductName=p.ProductName,UnitPrice=p.UnitPrice };
            foreach (var productDTO in result)
            {
                Console.WriteLine(productDTO.ProductName+" "+productDTO.CategoryName);
            }
        }

        private static void ClassicLinqTest(List<Product> products)
        {
            var result = from p in products
                         where p.UnitPrice > 6000
                         orderby p.UnitPrice
                         select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void AscAscWhereOrderby(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenBy(p => p.ProductName);
        }

        private static void WhereOrderByAsc(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice);
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void FindAllMethod(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("top"));
            Console.WriteLine(result);
        }

        private static void AnyMethod(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Laptop");
            Console.WriteLine(result);
        }

        private static void FindMethod(List<Product> products)
        {
            var result = products.Find(p => p.ProductId == 15);
            Console.WriteLine(result.ProductName);
        }

        private static void TestMethod(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                    Console.WriteLine(product.ProductName);
            }

            //Linq

            var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3);

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
   class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
