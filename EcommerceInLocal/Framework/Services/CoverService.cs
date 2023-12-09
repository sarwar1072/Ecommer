using AutoMapper;
using Framework.UnitOfWorkForApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoverEO = Framework.Entity.Cover;
using CoverBO = Framework.BusinessObj.Cover;
using Framework.Exceptions;

namespace Framework.Services
{
    public class CoverService : ICoverService
    {
        private IEcommerceUnitOfWork _ecommerceUnitOfWork;
        private IMapper _mapper;
        public CoverService(IEcommerceUnitOfWork ecommerceUnitOfWork
            ,IMapper mapper)
        {
            _ecommerceUnitOfWork= ecommerceUnitOfWork;  
            _mapper= mapper;
        }
        public void Add(CoverBO coverBO)
        {
            var entity = _ecommerceUnitOfWork.CoverRepository.GetCount(c => c.CoverType == coverBO.CoverType);

            if(entity>0)
              throw new DuplicationException("Same name exist",nameof(coverBO.CoverType));    

            var mapEntity=_mapper.Map<CoverEO>(coverBO); 
            _ecommerceUnitOfWork.CoverRepository.Add(mapEntity);
            _ecommerceUnitOfWork.Save();
        }
        public void EditCover(CoverBO coverBO)
        {
            var entity = _ecommerceUnitOfWork.CoverRepository.GetCount(x => x.CoverType == coverBO.CoverType);
            if (entity > 0)
                throw new DuplicationException("Duplicate value", nameof(coverBO.CoverType));

            var editEntity = _ecommerceUnitOfWork.CoverRepository.Get(x => x.Id == coverBO.Id).FirstOrDefault();
            AssignToEntity(editEntity, coverBO);
            _ecommerceUnitOfWork.CoverRepository.Edit(editEntity);
            _ecommerceUnitOfWork.Save();
        }
        private CoverEO AssignToEntity(CoverEO coverEO,CoverBO coverBO)
        {
            coverEO.CoverType = coverBO.CoverType;  
            return coverEO; 
        }
        public void Delete(int  id) 
        {
            var data = _ecommerceUnitOfWork.CoverRepository.GetById(id);

            _ecommerceUnitOfWork.CoverRepository.Remove(data);
            _ecommerceUnitOfWork.Save();    
        }
        public CoverBO GetById(int id) 
        {
            var singleEntity = _ecommerceUnitOfWork.CoverRepository.GetById(id);

            var mapEntity=_mapper.Map<CoverBO>(singleEntity);   
            return mapEntity;
        
        }
        public (IList<CoverBO> cover, int total, int totalDisplay) GetCover(int pageindex,int pagesize,string searchText,string orderBy)
        {
            (IList<CoverEO> data, int total, int totalDisplay) result = (null, 0, 0);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _ecommerceUnitOfWork.CoverRepository.GetDynamic(null, orderBy, "", pageindex, pagesize, true);
            }
            else
            {
                result = _ecommerceUnitOfWork.CoverRepository.GetDynamic(x => x.CoverType == searchText, orderBy, "", pageindex, pagesize, true);
            }

            var listOfEntity = new List<CoverBO>();
            foreach (var cover in result.data)
            {
                listOfEntity.Add(_mapper.Map<CoverBO>(cover));
            }
            return (listOfEntity, result.total, result.totalDisplay);
        }

        public void Dispose()
        {
            _ecommerceUnitOfWork.Dispose();  
        }
    }
}
