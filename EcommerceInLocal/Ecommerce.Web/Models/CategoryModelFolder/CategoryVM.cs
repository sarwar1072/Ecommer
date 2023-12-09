using Autofac;
using AutoMapper;
using Framework.Services;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Web.Models.CategoryModelFolder
{
    public class CategoryVM : IDisposable
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;
        private ILifetimeScope _lifetimeScope;
        public CategoryVM() { }     
        public CategoryVM(ICategoryService categoryService, IMapper mapper) 
        {
                _categoryService = categoryService; 
        }

        public void Dispose()
        {
            _categoryService.Dispose();
        }

        public  void ResolveDependency(ILifetimeScope lifetimeScope)
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
