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
        public ProductBaseModel(IMapper mapper, 
            IUserManagerAdapter<ApplicationUser> userManager, ILifetimeScope lifetimeScope):
            base(mapper,userManager)
        {
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _mapper = _lifetimeScope.Resolve<IMapper>();
           // _httpContextAccessor = _lifetimeScope.Resolve<IHttpContextAccessor>();
        }

        //public ResponesModelTwo Response2
        //{
        //    get
        //    {
        //        if (_httpContextAccessor.HttpContext.Session.IsAvailable &&
        //            _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response2)))
        //        {
        //            var response = _httpContextAccessor.HttpContext.Session.Get<ResponesModelTwo>(nameof(Response2));
        //            // Optional: Remove this line if you don't want to remove the session value immediately
        //            _httpContextAccessor.HttpContext.Session.Remove(nameof(Response2));
        //            return response;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    set
        //    {
        //        _httpContextAccessor.HttpContext.Session.Set(nameof(Response2), value);
        //    }
        //}

    }
}
