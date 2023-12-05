using CategoryBO=Framework.BusinessObj.Category;
using CategoryEO = Framework.Entity.Category;
using Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public interface ICategoryService: IDisposable
    {
        void AddCategory(CategoryBO categoryBO);
        void Edit(CategoryBO categoryBO);
        void Delete(int id);
        CategoryBO Get(int id);
        (IList<CategoryBO> category, int total, int totalDisplay) GetCategory(int pageindex, int pagesize,
                                                                              string searchText, string orderBy);
    }
}
