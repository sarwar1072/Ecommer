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
           public ProductDetailsModel(IProductServices productService)           
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
            }
        

    }
}
