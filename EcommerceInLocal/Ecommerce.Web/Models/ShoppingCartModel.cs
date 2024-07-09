using Autofac;
using AutoMapper;
using Framework.Entity;
using Framework.Services;
using Membership.BusinessObj;
using Membership.DTOS;
using Membership.Services;
using System.Threading.Tasks;
using Product = Framework.BusinessObj.Product;
namespace Ecommerce.Web.Models
{
    public class ShoppingCartModel:BaseModel
    {
        protected IShoppingCartServices _cartServices;
        protected IUserAccessor _userAccessor;

        public ShoppingCartModel(IUserAccessor userAccessor,IShoppingCartServices cartServices, IMapper mapper,IHttpContextAccessor httpContextAccessor,
            IUserManagerAdapter<ApplicationUser> userManager):base(mapper,httpContextAccessor, userManager)
        {
            _userAccessor = userAccessor;
              _cartServices = cartServices; 
        }        
        public override void ResolveDependency(ILifetimeScope scope)
        {
            _lifetimeScope = scope; 
            _cartServices=_lifetimeScope.Resolve<IShoppingCartServices>();  
            base.ResolveDependency(scope);  
        }
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int Count { get; set; }
        public ShoppingCartModel()
        {
                Count = 1;  
        }
        
        public void  AddCart()
        {
            //var load = _cartServices.GetCartById(id);
            //if(load != null)
            //{
            //    Id = Id;

            //}
            var model = new ShoppingCart()
            {
                ProductId= ProductId,   
                Count = Count,
                ApplicationUserId= ApplicationUserId,    
            };
             
          _cartServices.AddCart(model);
        }
    }
}






















