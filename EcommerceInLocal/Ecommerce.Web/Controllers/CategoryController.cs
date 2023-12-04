using Autofac;
using Ecommerce.Web.Models;
using Ecommerce.Web.Models.CategoryModelFolder;
using Framework.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Add()
        {
            var model= _lifetime.Resolve<CreateCategory>();
            return View(model); 
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(CreateCategory model)
        {                         
                 model.ResolveDependency(_lifetime);
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            model.Add();
                            ViewResponse("Success", ResponseType.Success);
                            return RedirectToAction(nameof(Index));
                        }
                        catch (DuplicationException ex)
                        {
                            ViewResponse("Duplicate", ResponseType.Duplicate);
                            return RedirectToAction(nameof(Index));
                        }
                       catch (Exception ex)
                        {
                            ViewResponse("Failure", ResponseType.Failure);

                        }               
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
