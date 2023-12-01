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
            var model = _lifetime.Resolve<CreateCategory>();
            return View(model);
        }
        public IActionResult Add()
        {
            var model= _lifetime.Resolve<CreateCategory>();
            return View(model); 
        }
        [HttpPost]
        public IActionResult Add(CreateCategory model)
        {
            model.ResolveDependency(_lifetime);
            if (ModelState.IsValid)
            {

                model.Add();
                ViewBag.Message = "Category created !";
                //return RedirectToAction("Index");
            }
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
