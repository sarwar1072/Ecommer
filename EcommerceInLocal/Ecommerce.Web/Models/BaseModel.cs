using Autofac;
using AutoMapper;
using Framework.Repositories;
using Microsoft.AspNetCore.Http;
using Framework;
using Azure;
using Membership.Services;
using Membership.DTOS;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Membership.BusinessObj;

namespace Ecommerce.Web.Models
{
    public  class BaseModel
    {
        protected IMapper? _mapper;
        protected ILifetimeScope?  _lifetimeScope;
       // protected IHttpContextAccessor _httpContextAccessor;
        protected IUserManagerAdapter<ApplicationUser> _userManager;
        public UserBasicInfo? basicInfo {get; private set;}
        public BaseModel() { }
        public BaseModel(IMapper mapper,
            IUserManagerAdapter<ApplicationUser> userManager)
        {
            _mapper = mapper;
            //_httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public virtual void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _mapper = _lifetimeScope.Resolve<IMapper>();
          // _httpContextAccessor = _lifetimeScope.Resolve<IHttpContextAccessor>();
            _userManager = _lifetimeScope.Resolve<IUserManagerAdapter<ApplicationUser>>();
        }
        //public   void GetUserInfo()
        //{
        //    var userName = _httpContextAccessor!.HttpContext!.User!.Identity!.Name;
        //    var userInfo= _userManager!.FindByUsernameAsync(userName!);
        //    basicInfo = new UserBasicInfo();
        //    _mapper!.Map(userInfo,userInfo); 
        //}
        //public ResponesModelTwo Response2
        //{
        //    get
        //    {
        //        if (_httpContextAccessor?.HttpContext?.Session != null &&
        //            _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response2)))
        //        {
        //            var response = _httpContextAccessor.HttpContext.Session.Get<ResponesModelTwo>(nameof(Response2));
        //            // Optional: Remove this line if you don't want to remove the session value immediately
        //            _httpContextAccessor.HttpContext.Session.Remove(nameof(Response2));
        //            return response;
        //        }
        //        else
        //        {
        //            return null;-
        //        }
        //    }
        //    set
        //    {
        //        if (_httpContextAccessor?.HttpContext?.Session != null)
        //        {
        //            _httpContextAccessor.HttpContext.Session.Set(nameof(Response2), value);
        //        }
        //    }
        //}


    }
}

/*

get
            {
                if (_httpContextAccessor?.HttpContext?.Session != null &&
                    _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response2)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponesModelTwo>(nameof(Response2));
// Optional: Remove this line if you don't want to remove the session value immediately
_httpContextAccessor.HttpContext.Session.Remove(nameof(Response2));

return response;
                }
                else
{
    return null;
}
            }
            set
            {
                if (_httpContextAccessor?.HttpContext?.Session != null)
                {
                    _httpContextAccessor.HttpContext.Session.Set(nameof(Response2), value);
                }
            }
*/