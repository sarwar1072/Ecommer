using Autofac;
using AutoMapper;
using Framework.Services;

namespace Ecommerce.Web.Models.CategoryModelFolder
{
    public class CategoryVM
    {
        private ICategoryService _categoryService;
        protected ILifetimeScope? _lifetimeScope;

        public CategoryVM() { }     
        public CategoryVM(ICategoryService categoryService)
        {
                _categoryService = categoryService; 
        }
        internal void ResolveDependancy(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _categoryService=_lifetimeScope.Resolve<ICategoryService>();
        }

        internal object GetCategory(DataTablesAjaxRequestModel dataTables)
        {
            var data = _categoryService.GetCategory(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "Name",
                                                     "DisplayOrder","CreatedDate"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.category
                        select new string[]
                        {
                            record.Name,    
                            record.DisplayOrder.ToString(),
                            record.CreatedDate.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }


    }
}
