using Autofac;
using Ecommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class AreaBaseController<T> : BaseController<T> where T : Controller
    {
        public AreaBaseController(ILifetimeScope scope, IUserAccessor userAccessor) :base(scope, userAccessor) 
        {            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
