using Ecommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Autofac;
using Ecommerce.Web.Models.CoverModelFolder;
using Framework.Exceptions;

namespace Ecommerce.Web.Controllers
{
    public class CoverController : Controller
    {
        private ILifetimeScope _lifetime;
        public CoverController(ILifetimeScope lifetime)
        {
            _lifetime = lifetime;
        }
        public IActionResult Index()
        {
            var model = _lifetime.Resolve<CoverVM>();
            return View(model);
        }
        public IActionResult Add()
        {
            var model = _lifetime.Resolve<CreateCover>();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(CreateCover model)
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model=_lifetime.Resolve<EditCover>();
            //var model = new EditCover();
            model.Load(id);
            return View(model); 
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(EditCover editCover)
        {
            editCover.ResolveDependency(_lifetime);
            if(ModelState.IsValid)
            {
                try
                {
                    editCover.EditModel();
                    ViewResponse("Success", ResponseType.Success);
                    return RedirectToAction(nameof(Index));
                } 
                catch(DuplicationException ex)
                { 
                    ViewResponse("Duplicate",ResponseType.Duplicate);   
                    return RedirectToAction(nameof(Index)); 
                }
                catch(Exception ex)
                {
                    ViewResponse("Failure", ResponseType.Failure);
                }
            }
            return View(editCover);
        }
        public IActionResult GetCover()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _lifetime.Resolve<CoverVM>();
            var data = model.GetCover(tableModel);
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
