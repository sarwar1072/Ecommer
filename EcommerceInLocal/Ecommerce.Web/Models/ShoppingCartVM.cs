using Autofac;
using AutoMapper;
using Framework.Entity;
using Framework.Entity.Membership;
using Framework.Services;
using Membership.Services;
using Microsoft.AspNetCore.Mvc;
using ApplicationUserEO = Membership.BusinessObj.ApplicationUser;
namespace Ecommerce.Web.Models
{
    public class ShoppingCartVM:BaseModel
    {
        protected IShoppingCartServices _cartServices;
        public ShoppingCartVM(IUserAccessor userAccessor, IShoppingCartServices cartServices, IMapper mapper,
            IUserManagerAdapter<ApplicationUserEO> userManager) : base(mapper, userManager)
        {
            _cartServices = cartServices;
        }
        public ShoppingCartVM() { }
        
        public override void ResolveDependency(ILifetimeScope scope)
        {
            _lifetimeScope = scope;
            _cartServices = _lifetimeScope.Resolve<IShoppingCartServices>();
            base.ResolveDependency(scope);
        }
        public IList<ShoppingCart> ListCart { get; set; } 
        public OrderHeader OrderHeader { get; set; }
        public ApplicationUser Auser { get; set; }
        public void GetCartDetails(Guid id)
        {
            _cartServices.GetShoppingCart(id);
        }

    }
}
