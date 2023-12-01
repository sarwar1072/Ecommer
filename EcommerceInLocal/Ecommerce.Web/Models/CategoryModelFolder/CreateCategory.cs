using Autofac;
using AutoMapper;
using Framework.Services;
using CategoryBO = Framework.BusinessObj.Category;

namespace Ecommerce.Web.Models.CategoryModelFolder
{
    public class CreateCategory
    {
        private ICategoryService _categoryService;
        protected ILifetimeScope? _lifetimeScope;
        private IMapper _mapper;

        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public CreateCategory() { }

        public CreateCategory(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;   
        }
        internal void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope; 
            _categoryService=_lifetimeScope.Resolve<ICategoryService>(); 
            _mapper= _lifetimeScope.Resolve<IMapper>(); 
        }

        public void Add()
        {
            var category2 = new CategoryBO()
            {
                Name = Name,    
                DisplayOrder = DisplayOrder,
                CreatedDate = CreatedDate,
            };
           // var category1=_mapper.Map<CategoryBO>(category2); 
            _categoryService.AddCategory(category2);
        }


             
    }
}
