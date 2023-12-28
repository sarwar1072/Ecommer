using Autofac;
using AutoMapper;
using Framework.Services;

namespace Ecommerce.Web.Models.ProductModelFolder
{
    public class ProductModel:ProductBaseModel
    {
        private IProductServices _services;
        public ProductModel() { }
        
        public ProductModel(  IProductServices services)           
        {
            _services = services;   
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _services = _lifetimeScope.Resolve<IProductServices>();
            base.ResolveDependency(_lifetimeScope);
        }

        internal object GetProduct(DataTablesAjaxRequestModel dataTables)
        {
            var data = _services.GetProduct(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "Title", "Description", "Author" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.products
                        select new string[]
                        {
                            record.Title,
                            record.Description,
                            record.ISBN,
                            record.Author,
                            record.Price.ToString(),
                            record.Category.Name,
                            record.ImageUrl,

                            record.Id.ToString()
                        }).ToArray()
            };
        }

    }
}
