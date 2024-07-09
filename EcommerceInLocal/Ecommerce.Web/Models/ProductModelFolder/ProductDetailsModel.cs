using Autofac;
using AutoMapper;
using Framework.BusinessObj;
using Framework.Services;
using Membership.BusinessObj;
using Membership.Services;
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

        public ICollection<Product>? ProductList { get; set; }
        public ICollection<Category>? CategoryList { get; set; }

        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }

        public ProductDetailsModel(IMapper mapper, IHttpContextAccessor httpContextAccessor, IProductServices productService,
            IUserManagerAdapter<ApplicationUser> userManager) :
            base(mapper, httpContextAccessor, userManager)
        {
            _productService = productService;   
        }
        
            public ProductDetailsModel() { }
            public override void ResolveDependency(ILifetimeScope lifetimeScope)
            {
                _lifetimeScope = lifetimeScope;
                _productService = _lifetimeScope.Resolve<IProductServices>();              
            }

        public void ListOfProduct(int? id, string term = "", int currentPage = 1)
        {
            var model=_productService.PagintList(id,term,true,currentPage); 

            if (model != null)
            {
                ProductList=new List<Product>();    
               foreach (var item in model.ProductList)
                {
                    ProductList.Add(new Product
                    {
                        Id = item.Id,
                        Title = item.Title, 
                        Description = item.Description, 
                        ISBN = item.ISBN,   
                        Author = item.Author,
                        Price = item.Price,
                        ImageUrl = item.ImageUrl,
                        CategoryId = item.CategoryId,   
                    });
                }
               CategoryList=new List<Category>();
                foreach (var category in model.CategoryList)
                {
                    CategoryList.Add(new Category
                    {
                        Id=category.Id, 
                        Name = category.Name,
                    });
                }
                PageSize = model.PageSize;  
                CurrentPage = model.CurrentPage;
                TotalPages = model.TotalPages;  
                //Term = model.Term;
            }


        }
        

    }
}
