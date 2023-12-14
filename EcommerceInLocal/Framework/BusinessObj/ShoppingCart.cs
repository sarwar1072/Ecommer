using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.BusinessObj
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        //public ShoppingCart()
        //{
        //    Count = 1;
        //}
    }
}
