using Autofac;
using Ecommerce.Web.Models;
using Framework.Entity;
using Framework.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Ecommerce.Web.Controllers
{
    public class CartController : AreaBaseController<CartController>
    {
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }       
        protected IShoppingCartServices _cartServices;
        public CartController(ILifetimeScope scope,IUserAccessor userAccessor,
            IShoppingCartServices cartServices) :base(scope,userAccessor) 
        {
                _cartServices= cartServices;    
        }
        [Authorize]
        public IActionResult IndexCart()
        {
            Guid UserId = CurrentUser != null ? CurrentUser.Id : Guid.Empty;
            var model = new ShoppingCartVM();
            model.OrderHeader = new OrderHeader();
           
            model.ListCart= _cartServices.GetShoppingCart(UserId);
            model.OrderHeader.OrderTotal = 0;
            foreach (var item in model.ListCart)
            {
                model.OrderHeader.OrderTotal += Result(item.Product.Price, item.Count);
            }
            return View(model);
        }
        private double Result(double price,int count)
        {
            return price * count;   
        }
        public IActionResult Plus(int cartId)
        {
            _cartServices.UpdateCart(cartId);
            return RedirectToAction(nameof(IndexCart));
        }
        public IActionResult Minus(int cartId)
        {
            _cartServices.MinusCart(cartId);
            return RedirectToAction(nameof(IndexCart));
        }
        public IActionResult Remove(int cartId) 
        {
            _cartServices.RemoveCart(cartId);
            return RedirectToAction(nameof(IndexCart));
        }

        public IActionResult Summary()
        {
            Guid UserId = CurrentUser != null ? CurrentUser.Id : Guid.Empty;

            return View();
        }
    }
}








