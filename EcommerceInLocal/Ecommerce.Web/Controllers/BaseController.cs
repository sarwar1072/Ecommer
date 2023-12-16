using Autofac;
using Ecommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class BaseController<T> : Controller where T:Controller
    {
        protected readonly ILifetimeScope _scope;
        public BaseController(ILifetimeScope scope)
        {
                _scope = scope; 
        }
        public IActionResult Index()
        {
            return View();
        }
        protected virtual void ViewResponse(string message, ResponseType responseTypes)
        {
            TempData.Put("ResponseMessage", new ResponseModel
            {
                Message = message,
                Type = responseTypes,
            });
        }
    }
}
