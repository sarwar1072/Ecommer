using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoverBO = Framework.BusinessObj.Cover;
using CoverEO = Framework.Entity.Cover;

namespace Framework.Services
{
    public interface ICoverService:IDisposable
    {
        void Add(CoverBO coverBO);
        void EditCover(CoverBO coverBO);
        void Delete(int id);
        CoverBO GetById(int id);
        (IList<CoverBO> cover, int total, int totalDisplay) GetCover(int pageindex, int pagesize, string searchText, string orderBy);
    }
}
