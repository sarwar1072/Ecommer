using Autofac;
using Ecommerce.Web.Models;
using Ecommerce.Web.Models.ProductModelFolder;
using Framework.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog.Configuration;
using System.Diagnostics;
using ProductBO = Framework.BusinessObj.Product;

namespace Ecommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductServices _productServices;
        private ILifetimeScope _lifetimeScope;

        public HomeController(ILogger<HomeController> logger, IProductServices productServices, ILifetimeScope lifetimeScope)
        {
            _logger = logger;
            _productServices = productServices;
            _lifetimeScope = lifetimeScope;
        }

        public IActionResult Index()
        {
            //var model = _lifetimeScope.Resolve<ProductDetailsModel>();
            //model.ListOfProduct();
            IList<ProductBO> listOfProduct = _productServices.GetProductDetails();

            return View(listOfProduct);
        }

        public IActionResult Details(int id)
        {
            var model = new ShoppingCartModel
            {
                Product = _productServices.GetOneProductDetails(id),
                  Count = 1
            };
            return View(model); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
