using Autofac;
using AutoMapper;
using Framework.Services;
using CategoryBO = Framework.BusinessObj.Category;
using CategoryEO = Framework.Entity.Category;
using Framework;

namespace Ecommerce.Web.Models.CategoryModelFolder
{
    public class EditCategory: IDisposable
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;
        private ILifetimeScope _lifetimeScope;
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
       
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public EditCategory() { }
        public EditCategory(ICategoryService categoryService, IMapper mapper) 
        {
            _categoryService = categoryService;
            _mapper = mapper;   


        }
        public  void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope; 
            _categoryService=_lifetimeScope.Resolve<ICategoryService>();
        }
       

        public void EditModel()
        {
            var category2 = new CategoryBO()
            {
                Id = Id,
                Name = Name,
                DisplayOrder = DisplayOrder,
                CreatedDate = CreatedDate,
            };
            // var category1=_mapper.Map<CategoryBO>(category2); 
            _categoryService.Edit(category2);
        }
        public void Load(int id)
        {
            var getData = _categoryService.Get(id);
            if (getData != null)
            {
                Id = getData.Id;
                Name = getData.Name;
                CreatedDate = getData.CreatedDate;
                DisplayOrder = getData.DisplayOrder;
            }
        }
        public void Delete(int id)
        {
            _categoryService.Delete(id);
        }
        public void Dispose()
        {
             _categoryService.Dispose();    
        }
    }
}
