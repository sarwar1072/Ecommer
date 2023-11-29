using AutoMapper;
using CategoryBO=Framework.BusinessObj.Category;
using CategoryEO = Framework.Entity.Category;
using Framework.UnitOfWorkForApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public class CategoryService:ICategoryService
    {
        private IEcommerceUnitOfWork _ecommerceUnitOf;
        private IMapper _mapper;
        public CategoryService(IEcommerceUnitOfWork ecommerceUnitOf,IMapper mapper)
        {
            _ecommerceUnitOf = ecommerceUnitOf;
            _mapper = mapper;   
        }
        public (IList<CategoryBO> category, int total, int totalDisplay) GetCategory(int pageindex, int pagesize,
                                                                              string searchText, string orderBy)
        {
            var result = _ecommerceUnitOf.CategoryRepository.GetDynamic(null, orderBy, "", pageindex, pagesize, true);

            var listOfEntity = new List<CategoryBO>();
            foreach (var category in result.data)
            {
                listOfEntity.Add(_mapper.Map<CategoryBO>(category));
            }
            return (listOfEntity, result.total, result.totalDisplay);
        }
       

    }
}
