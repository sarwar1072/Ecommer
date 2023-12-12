using Autofac.Core;
using Autofac;
using AutoMapper;
using Framework.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductBO = Framework.BusinessObj.Product;
using ProductEO = Framework.Entity.Product;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Web.Models.ProductModelFolder
{
    public class CreateProduct:ProductBaseModel
    {
        protected IProductServices _productService;
        //protected IMapper? _mapper;
        //protected ILifetimeScope? _lifetimeScope;
        //protected IHttpContextAccessor _httpContextAccessor;
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 10000)]

        public double Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public IFormFile formFile { get; set; }
        public int CategoryId { get; set; }
        public int CoverTypeId { get; set; }

        public CreateProduct(IProductServices productService,IMapper mapper,IHttpContextAccessor httpContextAccessor) 
           : base(mapper, httpContextAccessor)
        {
            _productService= productService;  
            //_mapper= mapper;    
            //_httpContextAccessor= httpContextAccessor;
        }
        public CreateProduct() { }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _productService = _lifetimeScope.Resolve<IProductServices>();
            //_mapper=_lifetimeScope.Resolve<IMapper>();
           // base.ResolveDependency(_lifetimeScope);
        }
        public void AddProduct()
        {
            var product = new ProductBO
            {
                Title = Title,
                Description = Description,
                ISBN = ISBN,
                Author = Author,
                Price = Price,
                ImageUrl = ImageUrl,
                CoverTypeId = CoverTypeId,
                CategoryId = CategoryId
            };
            _productService.AddProduct(product);
        }

        public IList<SelectListItem> ListOfCoverType()
        {
            var cover = new List<SelectListItem>();
            foreach (var item in _productService.GetCoverTypes())
            {
                var addItem = new SelectListItem
                {
                    Text = item.CoverType,
                    Value = item.Id.ToString()
                };
                cover.Add(addItem);
            }
            return cover;
        }

        public IList<SelectListItem> ListOfCategory()
        {
            var category = new List<SelectListItem>();
            foreach (var item in _productService.GetCategories())
            {
                var addItem = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                category.Add(addItem);
            }
            return category;
        }

    }
}
