using Autofac;
using AutoMapper;
using Framework.Services;
using Membership.BusinessObj;
using Membership.Services;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Web.Models.ProductModelFolder
{
    public class ProductBaseModel:BaseModel
    {

        public ProductBaseModel() { }
        public ProductBaseModel(IMapper mapper,IHttpContextAccessor httpContextAccessor ,
            IUserManagerAdapter<ApplicationUser> userManager):
            base(mapper, httpContextAccessor,userManager)
        {
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _mapper = _lifetimeScope.Resolve<IMapper>();
           // _httpContextAccessor = _lifetimeScope.Resolve<IHttpContextAccessor>();
        }

       

    }
}
