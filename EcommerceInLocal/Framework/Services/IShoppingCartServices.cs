using Autofac.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ShoppingCartBO = Framework.BusinessObj.ShoppingCart;
using  Framework.Entity;

namespace Framework.Services
{
    public interface IShoppingCartServices:IDisposable
    {
        void AddCart(ShoppingCart cartBO);
        ShoppingCart GetCartById(int id);
        IList<ShoppingCart> GetShoppingCart(Guid id);
        void UpdateCart(int id);
        void MinusCart(int id);
        void RemoveCart(int id);
    }
}
