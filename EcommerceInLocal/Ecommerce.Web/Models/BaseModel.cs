using Autofac;
using AutoMapper;
using Framework.Repositories;
using Framework.Services;
using Microsoft.AspNetCore.Http;
using Framework;

namespace Ecommerce.Web.Models
{
    public abstract class BaseModel
    {
        protected IMapper? _mapper;
        protected ILifetimeScope?  _lifetimeScope;
        protected IHttpContextAccessor _httpContextAccessor;
        public BaseModel() { }
        public BaseModel(IMapper mapper, IHttpContextAccessor httpContextAccessor)
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
        public ResponseModel Response
        {
            get
            {
                if(_httpContextAccessor.HttpContext.Session.IsAvailable && 
                    _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));
                    return response;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response),
                    value);
            }
        }
       

//        get
//            {
//                if (_httpContextAccessor?.HttpContext?.Session?.IsAvailable==true
//                    && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(response2)))
//                {
//                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(response2));
//        _httpContextAccessor.HttpContext.Session.Remove(nameof(response2));
//                    return response;
//                }
//                else
//                    return null;
//            }
//set
//            {
//                _httpContextAccessor.HttpContext.Session.Set(nameof(response2),
//        value);
//            }

    }
}
