using AutoMapper;
using Azure.Core;
using Framework.UnitOfWorkForApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ShoppingCartBO = Framework.BusinessObj.ShoppingCart;
using Framework.Entity;

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
        public void AddCart(ShoppingCart cartBO)
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
        public void UpdateCart(int id)
        {
            var cartNumber = _unitOfWork.ShoppingCartRepository.GetFirstOrDefault(x=>x.Id==id);
            cartNumber.Count++;
            _unitOfWork.ShoppingCartRepository.Edit(cartNumber);
            _unitOfWork.Save();
            
        }
        public ShoppingCart GetCartById(int id)
        {
           var result =_unitOfWork.ShoppingCartRepository.GetById(id);
            return result;
        }
        public IList<ShoppingCart> GetShoppingCart(Guid id)
        {
            var cartList=_unitOfWork.ShoppingCartRepository.GetAll(x=>x.ApplicationUserId==id,null,"Product");
            
            return cartList;
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
