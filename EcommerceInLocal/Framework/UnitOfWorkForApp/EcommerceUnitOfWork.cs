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
        public ICoverRepository CoverRepository {  get; private set; } 
        public IProductRepository ProductRepository { get; private set; }  
        public IShoppingCartRepository ShoppingCartRepository { get; private set; } 
        public ISellerRepository SellerRepository { get; private set; } 
        public EcommerceUnitOfWork(ApplicationDbContext dbContext, 
            ICategoryRepository categoryRepository,
            ICoverRepository coverRepository,
            IProductRepository productRepository,
            IShoppingCartRepository shoppingCartRepository,
            ISellerRepository sellerRepository) :base(dbContext)
        {
            CategoryRepository = categoryRepository;
            CoverRepository = coverRepository;
            ProductRepository = productRepository;
            ShoppingCartRepository = shoppingCartRepository;
            SellerRepository = sellerRepository;    
        }
    }
}
