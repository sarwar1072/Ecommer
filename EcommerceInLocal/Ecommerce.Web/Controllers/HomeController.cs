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
using Microsoft.EntityFrameworkCore;
using Autofac.Core.Lifetime;

namespace Ecommerce.Web.Controllers
{
    public class HomeController : AreaBaseController<HomeController>
    {
        private readonly ILogger<HomeController> _logger;
        private IProductServices _productServices;    
        private IEcommerceUnitOfWork _EcommerceUnit;
        public HomeController(IUserAccessor userAccessor,ILogger<HomeController> logger, IProductServices productServices, ILifetimeScope scope,
            IEcommerceUnitOfWork EcommerceUnit):base(scope, userAccessor)
        {
            _EcommerceUnit = EcommerceUnit;
            _logger = logger;
            _productServices = productServices;
        }
       // [HttpGet("{id?}")]
        public IActionResult IndexH(int? id,string term="",int currentPage=1)
        {
            var model = _scope.Resolve<ProductDetailsModel>();
            model.ResolveDependency(_scope);

             model.ListOfProduct(id,term,currentPage);
            //var listOfProduct = _productServices.PagintList(id,term,true, currentPage);
            return View(model);
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
            model.ResolveDependency(_scope);             
            model.ApplicationUserId = CurrentUser.Id;                     
            model.AddCart();
            return RedirectToAction(nameof(IndexH));
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
