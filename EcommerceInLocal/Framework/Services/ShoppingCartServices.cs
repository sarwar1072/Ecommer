using AutoMapper;
using Azure.Core;
using Framework.BusinessObj;
using Framework.UnitOfWorkForApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ShoppingCartBO = Framework.BusinessObj.ShoppingCart;
using ShoppingCartEO = Framework.Entity.ShoppingCart;

namespace Framework.Services
{
    public class ShoppingCartServices : IShoppingCartServices
    {
        private IEcommerceUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ShoppingCartServices(IEcommerceUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void AddCart(ShoppingCartEO cartBO)
        {
            var count=_unitOfWork.ShoppingCartRepository.GetFirstOrDefault
                (x=>x.ProductId==cartBO.ProductId && x.ApplicationUserId==cartBO.ApplicationUserId);
           // var modeEO = new ShoppingCartEO();
                       
             //var mapCartEO = AssignToEntity(cartBO, modeEO);          
            if (count ==null) 
            {
                _unitOfWork.ShoppingCartRepository.Add(cartBO);
                _unitOfWork.Save();
            }
            else
            {
                count.Count += cartBO.Count;
                _unitOfWork.ShoppingCartRepository.Edit(count);
                _unitOfWork.Save();
            }
        }
        public ShoppingCartEO GetCartById(int id)
        {
           var result =_unitOfWork.ShoppingCartRepository.GetById(id);
            return result;
        }
        //private ShoppingCartEO AssignToEntity(ShoppingCartBO cartBO,ShoppingCartEO modeEO)
        //{
            
        //    modeEO.ApplicationUserId = cartBO.ApplicationUerId;
        //    modeEO.ProductId= cartBO.ProductId; 
        //    modeEO.Count= cartBO.Count;
        //    return modeEO;
        //}
        public void Dispose()
        {
          _unitOfWork.Dispose();    
        }
    }
}
