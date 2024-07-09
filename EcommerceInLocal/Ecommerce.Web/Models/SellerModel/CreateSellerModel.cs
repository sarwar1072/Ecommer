using Autofac;
using AutoMapper;
using Framework.Services;
using Membership.BusinessObj;
using Membership.Services;

namespace Ecommerce.Web.Models.SellerModel
{
    public class CreateSellerModel:BaseModel
    {

        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        private ISellerServices _services;  
        public CreateSellerModel(IMapper mapper, IHttpContextAccessor httpContextAccessor,ISellerServices seller,
            IUserManagerAdapter<ApplicationUser> userManager, ILifetimeScope lifetimeScope) :
            base(mapper, httpContextAccessor, userManager)
        {
            _services=seller;
        }
        public CreateSellerModel()
        {
                
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _mapper = _lifetimeScope.Resolve<IMapper>();
             _services = _lifetimeScope.Resolve<ISellerServices>();
        }

        public void AddSeller()
        {
            var mode = new Framework.Entity.Seller
            {
               Name = Name,
               Description = Description,   
            };
            _services.Add(mode);    
        }

    }
}
