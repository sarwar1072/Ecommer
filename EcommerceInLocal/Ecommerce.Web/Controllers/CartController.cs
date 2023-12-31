using Autofac;
using Ecommerce.Web.Models;
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
           
            model.ListCart= _cartServices.GetShoppingCart(UserId);
            model.OrderTotal = 0;
            foreach (var item in model.ListCart)
            {
                model.OrderTotal += (item.Product.Price * item.Count);
            }
            return View(model);
        }
        public IActionResult Plus(int cartId)
        {
            _cartServices.UpdateCart(cartId);
            return RedirectToAction(nameof(IndexCart));
        }
    }
}








