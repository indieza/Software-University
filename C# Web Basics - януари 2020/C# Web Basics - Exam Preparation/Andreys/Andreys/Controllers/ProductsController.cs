namespace Andreys.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductViewModel product)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (product.Name.Length < 4 || product.Name.Length > 20)
            {
                return this.Redirect("/Products/Add");
            }

            if (product.Description.Length >= 10)
            {
                return this.Redirect("/Products/Add");
            }

            if (product.Price < 0)
            {
                return this.Redirect("/Products/Add");
            }

            int id = this.productsService.Add(product.Name,
                product.Description,
                product.ImageUrl,
                product.Price,
                product.Category,
                product.Gender);
            return this.Redirect($"/Products/Details?id={id}");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.productsService.GetProduct(id);
            return this.View(product, "Details");
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.DeleteById(id);
            return this.Redirect("/");
        }
    }
}