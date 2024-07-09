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
    public class SellerRepository:Repository<Seller,int,ApplicationDbContext>, ISellerRepository    
    {
        public SellerRepository(ApplicationDbContext dbContext):base(dbContext) { }
       
    }
}
