using Autofac;
using Ecommerce.Web.Models;
using Framework.Entity.Membership;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class BaseController<T> : Controller where T:Controller
    {
        protected readonly ILifetimeScope _scope;
        protected IUserAccessor _userAccessor;

        public BaseController(ILifetimeScope scope, IUserAccessor userAccessor)
        {
                _scope = scope;
            _userAccessor = userAccessor;
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
