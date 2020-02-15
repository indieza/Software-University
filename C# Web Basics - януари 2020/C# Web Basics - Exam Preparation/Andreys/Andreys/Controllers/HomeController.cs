namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var products = this.productsService.GetAll();
                return this.View(products, "Home");
            }

            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            if (this.IsUserLoggedIn())
            {
                var products = this.productsService.GetAll();
                return this.View(products, "Home");
            }

            return this.View("Index");
        }
    }
}