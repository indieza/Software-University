using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new ProductShopContext();
            //db.Database.EnsureCreated();

            var file = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\08. JSON - Exercise\Product Shop\ProductShop\Datasets\categories-products.json");

            Console.WriteLine(ImportCategoryProducts(db, file));
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
    }
}