using AutoMapper;
using CategoryBO=Framework.BusinessObj.Category;
using CategoryEO = Framework.Entity.Category;
using Framework.UnitOfWorkForApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Exceptions;
using System.Net.WebSockets;

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
        public void AddCategory(CategoryBO categoryBO) 
        {
            var entityCount=_ecommerceUnitOf.CategoryRepository.GetCount(c=>c.Name==categoryBO.Name);
            if(entityCount > 0)
            {
                throw new DuplicationException("Same title is exist",nameof(categoryBO.Name));
            }
            var mapEntity=_mapper.Map<CategoryEO>(categoryBO);  
            _ecommerceUnitOf.CategoryRepository.Add(mapEntity);
            _ecommerceUnitOf.Save();

        }
        public void Dispose()
        {
            _ecommerceUnitOf.Dispose();
        }
        public void Edit(CategoryBO categoryBO)
        {
            var count=_ecommerceUnitOf.CategoryRepository.GetCount(c=>c.Name == categoryBO.Name);
            if (count > 0)
                 throw new DuplicationException("Already exist", nameof(categoryBO.Name));

            var entity = _ecommerceUnitOf.CategoryRepository.Get(x=>x.Id==categoryBO.Id).FirstOrDefault();
            AssignToEntity(categoryBO, entity);

            _ecommerceUnitOf.CategoryRepository.Edit(entity); 
            _ecommerceUnitOf.Save();    
        }
        private CategoryEO AssignToEntity(CategoryBO categoryBO,CategoryEO categoryEO)
        {    
            categoryEO.Id=categoryBO.Id;
            categoryEO.Name = categoryBO.Name;
            categoryEO.DisplayOrder = categoryBO.DisplayOrder;
            categoryEO.CreatedDate=categoryBO.CreatedDate;

            return categoryEO;
        }   
        public void Delete(int id)
        {
            var entity=_ecommerceUnitOf.CategoryRepository.GetById(id);
            _ecommerceUnitOf.CategoryRepository.Remove(entity); 
            _ecommerceUnitOf.Save();
        }
        public CategoryBO Get(int id)
        {
             var entityObj=_ecommerceUnitOf.CategoryRepository.GetById(id);
            var businessObj = _mapper.Map<CategoryBO>(entityObj);
            return businessObj;
            //return entityObj;
        }
        public (IList<CategoryBO> category, int total, int totalDisplay) GetCategory(int pageindex, int pagesize,
                                                                              string searchText, string orderBy)
        {
            (IList<CategoryEO> data, int total, int totalDisplay) result = (null, 0, 0);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _ecommerceUnitOf.CategoryRepository.GetDynamic(null, orderBy, "", pageindex, pagesize, true);
            }
            else
            {
                result = _ecommerceUnitOf.CategoryRepository.GetDynamic(x => x.Name == searchText, orderBy, "", pageindex, pagesize, true);
            }
            var listOfEntity = new List<CategoryBO>();
            foreach (var category in result.data)
            {
                listOfEntity.Add(_mapper.Map<CategoryBO>(category));
            }
            return (listOfEntity, result.total, result.totalDisplay);
        }
       

    }
}
