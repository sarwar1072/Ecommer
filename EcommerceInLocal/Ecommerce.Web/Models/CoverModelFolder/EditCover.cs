using Autofac;
using AutoMapper;
using Framework.Services;
using CoverBO = Framework.BusinessObj.Cover;
using Framework;

namespace Ecommerce.Web.Models.CoverModelFolder
{
    public class EditCover: IDisposable
    {
        private ICoverService _coverService;
        private IMapper _mapper;
        private ILifetimeScope _lifetimeScope;
        public int Id { get; set; }
        public string CoverType { get; set; }
        public EditCover() { }
        public EditCover(ICoverService coverService, IMapper mapper) 
        {
            _coverService = coverService;
            _mapper = mapper;   
        }
        public  void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _coverService = _lifetimeScope.Resolve<ICoverService>();
        }    
        public void EditModel()
        {
            var cover = new CoverBO()
            {
                Id = Id,
                CoverType = CoverType,  
            };
            // var category1=_mapper.Map<CategoryBO>(category2); 
            _coverService.EditCover(cover);
        }
        public void Load(int id)
        {
            var getData = _coverService.GetById(id);
            if (getData != null)
            {
                Id = getData.Id;
                CoverType = getData.CoverType;             
            }
        }
        public void Delete(int id)
        {
            _coverService.Delete(id);
        }
        public void Dispose()
        {
            _coverService.Dispose();    
        }
    }
}
