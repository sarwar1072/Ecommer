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
using Framework.Exceptions;
using Newtonsoft.Json;

namespace Ecommerce.Web.Models
{
    public abstract class BaseModel
    {
        protected IMapper? _mapper;
        protected ILifetimeScope? _lifetimeScope;
        protected IHttpContextAccessor _httpContextAccessor;
        protected IUserManagerAdapter<ApplicationUser> _userManager;
        public UserBasicInfo? basicInfo { get; private set; }
        public BaseModel() { }
        public BaseModel(IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IUserManagerAdapter<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public virtual void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _mapper = _lifetimeScope.Resolve<IMapper>();
            _httpContextAccessor = _lifetimeScope.Resolve<IHttpContextAccessor>();
            _userManager = _lifetimeScope.Resolve<IUserManagerAdapter<ApplicationUser>>();
        }
        public ResponesModelTwo? Response { get; set; }
       

    }
}