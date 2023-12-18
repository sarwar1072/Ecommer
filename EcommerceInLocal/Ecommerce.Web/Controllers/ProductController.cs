using Ecommerce.Web.Models;
using Framework.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Autofac;
using Ecommerce.Web.Models.ProductModelFolder;
using Microsoft.AspNetCore.Hosting;
using Ecommerce.Web.Models.CoverModelFolder;

namespace Ecommerce.Web.Controllers
{
    public class ProductController : AreaBaseController<ProductController>
    {
        //protected ILifetimeScope _lifetime;
        IFileHelper _fileHelper;
        //private  IHttpContextAccessor _httpContextAccessor;

        public ProductController(ILifetimeScope scope,IFileHelper fileHelper):base(scope)
        {
            _fileHelper = fileHelper;
            //_httpContextAccessor = httpContextAccessor;
        }
        public IActionResult IndexP()
        {
            var model = _scope.Resolve<ProductModel>();
            return View(model);
        }
        public IActionResult Add()
        {
            var model = _scope.Resolve<CreateProduct>();
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Add(CreateProduct model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {                 
                   // model.ImageUrl = _fileHelper.UploadFile(model.formFile);
                    model.AddProduct();
                 // model.Response2=new ResponesModelTwo("Success",ResponseType.Success);    
                    ViewResponse("Success", ResponseType.Success);
                    return RedirectToAction(nameof(Index));
                }
                catch (DuplicationException ex)
                {
                    //model.Response2 = new ResponesModelTwo("Duplicate", ResponseType.Success);
                    ViewResponse("Duplicate", ResponseType.Duplicate);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //model.Response2 = new ResponesModelTwo("Failure", ResponseType.Success);
                    ViewResponse("Failure", ResponseType.Failure);
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
            var model = _scope.Resolve<ProductModel>();
            var data = model.GetProduct(tableModel);
            return Json(data);
        }

        
    }
}
