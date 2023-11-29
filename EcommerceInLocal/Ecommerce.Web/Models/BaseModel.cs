using Autofac;
using AutoMapper;
using Framework.Repositories;
using Framework.Services;

namespace Ecommerce.Web.Models
{
    public abstract class BaseModel
    {
        protected IMapper? _mapper;
        protected ILifetimeScope?  _lifetimeScope;
        public BaseModel() { }
        
        public BaseModel(ILifetimeScope lifetimeScope,IMapper mapper)
        {
            _lifetimeScope = lifetimeScope;
            _mapper = mapper;
        }
    }
}
