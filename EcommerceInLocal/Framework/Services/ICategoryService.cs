using CategoryBO=Framework.BusinessObj.Category;
using Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public interface ICategoryService
    {
        void AddCategory(CategoryBO categoryBO);
        (IList<CategoryBO> category, int total, int totalDisplay) GetCategory(int pageindex, int pagesize,
                                                                              string searchText, string orderBy);
    }
}
