using DataAccessLayer;
using Framework.ContextClass;
using Framework.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repositories
{
    public class ShoppingCartRepository:Repository<ShoppingCart,int,ApplicationDbContext>,IShoppingCartRepository
    {
        public ShoppingCartRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        
    }    
}
