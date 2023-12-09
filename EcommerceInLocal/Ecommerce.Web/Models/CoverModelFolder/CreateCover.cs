using Autofac;
using AutoMapper;
using Framework.Services;
using CoverBO = Framework.BusinessObj.Cover;
using Framework;

namespace Ecommerce.Web.Models.CoverModelFolder
{
    public class CreateCover: IDisposable
    {
        private ICoverService _coverService;
        private IMapper _mapper;
        private ILifetimeScope _lifetimeScope;
        public int Id { get; set; }
        public string CoverType { get; set; }
       
        public CreateCover() { }
        public CreateCover(ICoverService coverService, IMapper mapper) 
        {
            _coverService = coverService;
            _mapper = mapper;   
        }
        public  void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _coverService = _lifetimeScope.Resolve<ICoverService>();
        }


        public void Add()
        {
            var cover = new CoverBO()
            {
               CoverType = CoverType,   
            };
            // var category1=_mapper.Map<CategoryBO>(category2); 
            _coverService.Add(cover);
        }

        public void Dispose()
        {
            _coverService.Dispose();
        }
    }
}
