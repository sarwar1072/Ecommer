using DataAccessLayer;
using Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UnitOfWorkForApp
{
    public interface IEcommerceUnitOfWork:IUnitOfWork
    {
         ICategoryRepository CategoryRepository { get;  }
    }
}
