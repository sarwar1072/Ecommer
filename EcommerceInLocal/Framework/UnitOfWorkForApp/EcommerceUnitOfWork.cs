using DataAccessLayer;
using Framework.ContextClass;
using Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UnitOfWorkForApp
{
    public class EcommerceUnitOfWork:UnitOfWork, IEcommerceUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; private set; }
        public EcommerceUnitOfWork(ApplicationDbContext dbContext, 
            ICategoryRepository categoryRepository) :base(dbContext)
        {
            CategoryRepository = categoryRepository;
        }
    }
}
