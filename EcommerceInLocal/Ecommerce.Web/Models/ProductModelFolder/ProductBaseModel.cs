using Autofac;
using AutoMapper;
using Framework.Services;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Web.Models.ProductModelFolder
{
    public class ProductBaseModel
    {
        protected IMapper? _mapper;
        protected ILifetimeScope? _lifetimeScope;
        protected  IHttpContextAccessor _httpContextAccessor;
        public ProductBaseModel() { }
        public ProductBaseModel(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public virtual void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _mapper = _lifetimeScope.Resolve<IMapper>();
            _httpContextAccessor = _lifetimeScope.Resolve<IHttpContextAccessor>();
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
