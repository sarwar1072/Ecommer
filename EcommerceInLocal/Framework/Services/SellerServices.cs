using Framework.Entity;
using Framework.Exceptions;
using Framework.UnitOfWorkForApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public class SellerServices:ISellerServices
    {
        public IEcommerceUnitOfWork _ecommerceUnitOf;
        public SellerServices(IEcommerceUnitOfWork ecommerceUnitOf)
        {
                _ecommerceUnitOf = ecommerceUnitOf;
        }

        public void Add(Seller  seller)
        {
            var entity = _ecommerceUnitOf.SellerRepository.GetCount(c => c.Name == seller.Name);

            if (entity > 0)
                throw new DuplicationException2("Same name exist", nameof(seller.Name));

            _ecommerceUnitOf.SellerRepository.Add(seller);
            _ecommerceUnitOf.Save();           
        }

    }
}
