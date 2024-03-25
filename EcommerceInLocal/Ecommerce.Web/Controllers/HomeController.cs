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
        public IActionResult IndexH(string term="",int currentPage=1,int id=0)
        {
           
            var listOfProduct = _productServices.PagintList(term,true, currentPage, id);
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
