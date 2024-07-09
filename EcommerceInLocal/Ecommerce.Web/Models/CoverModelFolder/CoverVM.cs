using Autofac;
using AutoMapper;
using Framework.Services;
using Membership.BusinessObj;
using Membership.Services;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Web.Models.CoverModelFolder
{
    public class CoverVM: BaseModel
    {
        private ICoverService _coverService;
        //private IMapper _mapper;
        //private ILifetimeScope _lifetimeScope;

        public CoverVM(IMapper mapper, IHttpContextAccessor httpContextAccessor, ICoverService seller,
           IUserManagerAdapter<ApplicationUser> userManager, ILifetimeScope lifetimeScope) :
           base(mapper, httpContextAccessor, userManager)
        {
            _coverService = seller;
        }
        public CoverVM()
        {

        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _mapper = _lifetimeScope.Resolve<IMapper>();
            _coverService = _lifetimeScope.Resolve<ICoverService>();
        }
        public CoverVM(ICoverService coverService, IMapper mapper) 
        {
            _coverService = coverService; 
        }

        public void Dispose()
        {
            _coverService.Dispose();
        }

        //public  void ResolveDependency(ILifetimeScope lifetimeScope)
        //{
        //    _lifetimeScope = lifetimeScope;
        //    _coverService=_lifetimeScope.Resolve<ICoverService>();
        //}

        internal object GetCover(DataTablesAjaxRequestModel dataTables)
        {
            var data = _coverService.GetCover(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "CoverType", }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.cover
                        select new string[]
                        {
                            record.CoverType,                               
                            record.Id.ToString()
                        }).ToArray()
            };
        }


    }
}
