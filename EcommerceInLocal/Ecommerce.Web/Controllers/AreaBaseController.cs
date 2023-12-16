using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class AreaBaseController<T> : BaseController<T> where T : Controller
    {
        public AreaBaseController(ILifetimeScope scope):base(scope) 
        {            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
