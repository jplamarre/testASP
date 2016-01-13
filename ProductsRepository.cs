using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApp.Repositories
{
    public class ProductsRepository
    {
        private const string CacheKey = "ProductStore";

        public ProductsRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var products = new Product[]
                    {
                        
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
                new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
                new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
                    };

                    ctx.Cache[CacheKey] = products;
                }
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Product[])ctx.Cache[CacheKey];
            }

            return new Product[]
            {
                new Product
                {
                    Id = 0,
                    Name = "Patate",
                    Category = "Groceries",
                    Price = 2
                }
            };
        }

        public Product GetProduct(int id)
        {
            var products = GetAllProducts(); 
            var product = products.FirstOrDefault((p) => p.Id == id);
            return product;
        }

        public bool SaveProduct(Product product)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Product[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(product);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }

            }

            return false;
        }

    }
    }
