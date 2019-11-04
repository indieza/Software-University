using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dto;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            //context.Database.EnsureCreated();

            var file = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\08. JSON - Exercise\Product Shop\ProductShop\Datasets\categories-products.json");

            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var product = JsonConvert.DeserializeObject<Product[]>(inputJson);
            context.Products.AddRange(product);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null);
            context.Categories.AddRange(categories);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoryProducts.AddRange(categoriesProducts);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var exportedProducts = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();

            var json = JsonConvert.SerializeObject(exportedProducts, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var exportedSoldProducts = context.Users
                .Where(u => u.ProductsSold.Count() >= 1)
                .Select(u => new SellerDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(p => p.BuyerId != null)
                    .Select(p => new SoldProductDto
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName);

            var json = JsonConvert.SerializeObject(exportedSoldProducts, Formatting.Indented);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var exportCategories = context.Categories
                .Select(c => new CategoriesDto
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = Math.Round(c.CategoryProducts.Average(p => p.Product.Price), 2),
                    TotalRevenue = Math.Round(c.CategoryProducts.Sum(p => p.Product.Price), 2)
                })
                .OrderByDescending(p => p.ProductsCount)
                .ToList();

            var json = JsonConvert.SerializeObject(exportCategories, Formatting.Indented);

            return json;
        }
    }
}