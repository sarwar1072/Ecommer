using Autofac.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ShoppingCartBO = Framework.BusinessObj.ShoppingCart;
using ShoppingCartEO = Framework.Entity.ShoppingCart;

namespace Framework.Services
{
    public interface IShoppingCartServices:IDisposable
    {
        void AddCart(ShoppingCartEO cartBO);
        ShoppingCartEO GetCartById(int id);
    }
}
