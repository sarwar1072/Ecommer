using DataAccessLayer;
using Framework.ContextClass;
using Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repositories
{
    public class OrderHeaderRepository:Repository<OrderHeader,int,ApplicationDbContext>, IOrderHeaderRepository
    {
        public OrderHeaderRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
                
        }
    }
}
