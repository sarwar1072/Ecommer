using Autofac;
using Autofac.Core.Lifetime;
using Ecommerce.Web.Models;
using Ecommerce.Web.Models.CategoryModelFolder;
using Framework.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ecommerce.Web.Controllers
{
    public class CategoryController : AreaBaseController<CategoryController>
    {
        
       public CategoryController(ILifetimeScope scope):base(scope)    
        {
        }
        public IActionResult IndexC()
        {
            var model = _scope.Resolve<CategoryVM>();
            return View(model);
        }
        public IActionResult Add()
        {
            var model= _scope.Resolve<CreateCategory>();
            return View(model); 
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(CreateCategory model)
        {                         
                 model.ResolveDependency(_scope);
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model=_scope.Resolve<EditCategory>();
            model.Load(id);
            return View(model); 
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditCategory editCategory)
        {
            editCategory.ResolveDependency(_scope);
            
            if (ModelState.IsValid)
            {
                try
                {
                    editCategory.EditModel();
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
            return View(editCategory);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _scope.Resolve<EditCategory>();
                 model.Delete(id);
                ViewResponse("Question has been successfully deleted.", ResponseType.Success);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Failed to delete Question");
                ViewResponse(ex.Message, ResponseType.Failure);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetCategory()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<CategoryVM>();
            var data = model.GetCategory(tableModel);
            return Json(data);
        }
        
    }
}
