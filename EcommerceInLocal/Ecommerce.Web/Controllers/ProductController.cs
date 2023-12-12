using Ecommerce.Web.Models;
using Framework.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Autofac;
using Ecommerce.Web.Models.ProductModelFolder;
using Microsoft.AspNetCore.Hosting;
using Ecommerce.Web.Models.CoverModelFolder;

namespace Ecommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private ILifetimeScope _lifetime;
        IFileHelper _fileHelper;
        private  IHttpContextAccessor _httpContextAccessor;

        public ProductController(ILifetimeScope lifetime,IFileHelper fileHelper,
            IHttpContextAccessor httpContextAccessor)
        {
            _lifetime = lifetime;
            _fileHelper = fileHelper;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var model = _lifetime.Resolve<ProductModel>();
            return View(model);
        }
        public IActionResult Add()
        {
            var model = _lifetime.Resolve<CreateProduct>();
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Add(CreateProduct model)
        {
            model.ResolveDependency(_lifetime);
            if (ModelState.IsValid)
            {
                try
                {
                    model.ImageUrl = _fileHelper.UploadFile(model.formFile);
                    model.AddProduct();
                 //  model.Response2=new ResponesModelTwo("Success",ResponseType.Success);    
                    ViewResponse("Success", ResponseType.Success);
                    return RedirectToAction(nameof(Index));
                }
                catch (DuplicationException ex)
                {
                    ViewResponse("Success", ResponseType.Duplicate);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewResponse("Success", ResponseType.Failure);
                }
            }
            return View(model);
        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var model = _lifetime.Resolve<EditCategory>();
        //    model.Load(id);
        //    return View(model);
        //}

        public IActionResult GetProduct()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _lifetime.Resolve<ProductModel>();
            var data = model.GetProduct(tableModel);
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
