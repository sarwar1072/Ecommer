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
    public class ProductRepository:Repository<Product,int,ApplicationDbContext>, IProductRepository 
    {
        public ProductRepository(ApplicationDbContext dbContext):base(dbContext)
        {
                
        }
    }
}
