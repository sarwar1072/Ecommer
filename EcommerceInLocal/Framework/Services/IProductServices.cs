using ProductBO=Framework.BusinessObj.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryBO = Framework.BusinessObj.Category;
using CoverBO = Framework.BusinessObj.Cover;
using Framework.BusinessObj;

namespace Framework.Services
{
    public interface IProductServices:IDisposable
    {
        void AddProduct(ProductBO productBO);
        IList<CategoryBO> GetCategories();
        IList<CoverBO> GetCoverTypes();
        IEnumerable<ProductBO> GetProductDetails();
        ProductBO GetOneProductDetails(int id);
        DisplayCategory DisplayList(string SearchCategory = "");
        (IList<ProductBO> products, int total, int totalDisplay) GetProduct(int pageindex, int pagesize,
                                                                             string searchText, string orderBy);
        ProductDetails PagintList(int? id,string term = "",bool paging = false, int currentPage = 0);
    }
}
