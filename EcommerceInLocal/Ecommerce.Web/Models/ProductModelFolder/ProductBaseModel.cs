using Autofac;
using AutoMapper;
using Framework.Services;

namespace Ecommerce.Web.Models.ProductModelFolder
{
    public class ProductBaseModel:BaseModel
    {
       // private IProductServices _services; 
        public ProductBaseModel(IMapper mapper, IHttpContextAccessor httpContextAccessor 
           ) :
            base( mapper, httpContextAccessor)
        {
            //_services = services;
        }
        public ProductBaseModel() { }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _mapper = _lifetimeScope.Resolve<IMapper>();
            //_services = _lifetimeScope.Resolve<IProductServices>();
        }

        
    }
}
