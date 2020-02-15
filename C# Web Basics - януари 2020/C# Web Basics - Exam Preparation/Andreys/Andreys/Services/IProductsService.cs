namespace Andreys.Services
{
    using Andreys.ViewModels.Products;
    using System.Collections.Generic;

    public interface IProductsService
    {
        int Add(string name, string description, string imageUrl, decimal price, string category, string gender);

        IEnumerable<ProductsHomeViewModel> GetAll();

        ProductDetailsViewModel GetProduct(int id);

        void DeleteById(int id);
    }
}