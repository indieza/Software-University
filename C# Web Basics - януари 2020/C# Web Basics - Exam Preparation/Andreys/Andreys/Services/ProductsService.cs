namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Models;
    using Andreys.ViewModels.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext dbContext;

        public ProductsService(AndreysDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(string name, string description, string imageUrl, decimal price, string category, string gender)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Price = price,
                Category = Enum.Parse<CategoryType>(category),
                Gender = Enum.Parse<GenderType>(gender)
            };

            this.dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return product.Id;
        }

        public void DeleteById(int id)
        {
            var product = this.dbContext.Products.Find(id);
            this.dbContext.Products.Remove(product);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<ProductsHomeViewModel> GetAll()
        {
            return this.dbContext.Products.Select(x => new ProductsHomeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImageUrl = x.ImageUrl
            })
            .ToArray();
        }

        public ProductDetailsViewModel GetProduct(int id)
        {
            return this.dbContext.Products.Where(x => x.Id == id).Select(p => new ProductDetailsViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Category = p.Category.ToString(),
                Gender = p.Gender.ToString()
            }).FirstOrDefault();
        }
    }
}