using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var users = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\09. XML Processing - Exercise\ProductShop\ProductShop\Datasets\users.xml");

            //var products = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\09. XML Processing - Exercise\ProductShop\ProductShop\Datasets\products.xml");

            //var categories = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\09. XML Processing - Exercise\ProductShop\ProductShop\Datasets\categories.xml");

            //var categoriesProducts = File.ReadAllText(@"D:\Documents\GitHub\Software-University\Entity Framework\01. Homeworks\09. XML Processing - Exercise\ProductShop\ProductShop\Datasets\categories-products.xml");

            //Console.WriteLine(ImportUsers(context, users));
            //Console.WriteLine(ImportProducts(context, products));
            //Console.WriteLine(ImportCategories(context, categories));
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProducts));

            Console.WriteLine(GetProductsInRange(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));
            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<User> users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));
            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Product> products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer =
                new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));
            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Category> categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                var category = Mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer =
                new XmlSerializer(typeof(ImportCategoryProductsDto[]),
                new XmlRootAttribute("CategoryProducts"));
            var categoryProductsDto =
                ((ImportCategoryProductsDto[])xmlSerializer.Deserialize(new StringReader(inputXml)))
                .ToList();

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                var targetProduct = context.Products.Find(categoryProductDto.ProductId);
                var targetCategory = context.Categories.Find(categoryProductDto.CategoryId);

                if (targetProduct != null && targetCategory != null)
                {
                    var category = Mapper.Map<CategoryProduct>(categoryProductDto);
                    categoryProducts.Add(category);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            var xmlSerializer =
                new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute("Products"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}