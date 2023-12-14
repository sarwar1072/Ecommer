using Autofac;
using AutoMapper;
using Framework.Services;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Web.Models.ProductModelFolder
{
    public class ProductDetailsModel:ProductBaseModel
    {
            protected IProductServices _productService;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        //public string ImageUrl { get; set; }
        //[Required]
        //public IFormFile formFile { get; set; }
        //public int CategoryId { get; set; }
        //public int CoverTypeId { get; set; }

        public ProductDetailsModel(IProductServices productService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
               : base(mapper, httpContextAccessor)
            {
                _productService = productService;
                // _mapper= mapper;    
                //_httpContextAccessor= httpContextAccessor;
            }
            public ProductDetailsModel() { }
            public override void ResolveDependency(ILifetimeScope lifetimeScope)
            {
                _lifetimeScope = lifetimeScope;
                _productService = _lifetimeScope.Resolve<IProductServices>();
                // _mapper=_lifetimeScope.Resolve<IMapper>();
                // base.ResolveDependency(_lifetimeScope);
            }
        //public void ListOfProduct()
        //{
        //    var list = _productService.GetProductDetails();
        //    foreach (var item in list)
        //    {

        //    }
            
        //}


        }
}
