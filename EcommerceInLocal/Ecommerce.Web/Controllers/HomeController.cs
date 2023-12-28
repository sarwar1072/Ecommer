using Autofac;
using Ecommerce.Web.Models;
using Ecommerce.Web.Models.ProductModelFolder;
using Framework.Entity.Membership;
using Framework.Services;
using Framework.UnitOfWorkForApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog.Configuration;
using System.Diagnostics;
using System.Security.Claims;
using ProductBO = Framework.BusinessObj.Product;

namespace Ecommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductServices _productServices;
        private ILifetimeScope _lifetimeScope;
        protected IUserAccessor _userAccessor;
        private IEcommerceUnitOfWork _EcommerceUnit;    
        public HomeController(IUserAccessor userAccessor,ILogger<HomeController> logger, IProductServices productServices, ILifetimeScope lifetimeScope,
            IEcommerceUnitOfWork EcommerceUnit)
        {
            _EcommerceUnit = EcommerceUnit;
            _userAccessor =userAccessor; 
            _logger = logger;
            _productServices = productServices;
            _lifetimeScope = lifetimeScope;
        }
        public ApplicationUser CurrentUser
        {
            get
            {
                if (User != null)
                    return _userAccessor.GetUser();
                else
                    return null;
            }
        }
        public IActionResult Index()
        {
            //var model = _lifetimeScope.Resolve<ProductDetailsModel>();
            //model.ListOfProduct();
            IList<ProductBO> listOfProduct = _productServices.GetProductDetails();
            return View(listOfProduct);
        }
        public IActionResult Details(int productId)
        {
            var model = new ShoppingCartModel
            {
                Product = _productServices.GetOneProductDetails(productId),
                  Count = 1,
                  Id= productId
            };
            return View(model); 
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCartModel model)
        {       
            model.ResolveDependency(_lifetimeScope);             
            model.ApplicationUserId = CurrentUser.Id;                     
            model.AddCart();
            return RedirectToAction(nameof(Index));
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
