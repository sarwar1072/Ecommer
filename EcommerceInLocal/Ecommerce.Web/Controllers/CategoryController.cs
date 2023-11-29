using Autofac;
using Ecommerce.Web.Models;
using Ecommerce.Web.Models.CategoryModelFolder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ILifetimeScope _lifetime;
        public CategoryController(ILifetimeScope lifetime)
        {
            _lifetime = lifetime;
        }
        public IActionResult Index()
        {
            var model = _lifetime.Resolve<CategoryVM>();
            return View(model);
        }

        public IActionResult GetCategory()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _lifetime.Resolve<CategoryVM>();
            var data = model.GetCategory(tableModel);
            return Json(data);
        }
    }
}
