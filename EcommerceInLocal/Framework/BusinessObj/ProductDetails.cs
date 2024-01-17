using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEO = Framework.Entity.Product;
namespace Framework.BusinessObj
{
    public class ProductDetails
    {
        public IQueryable<ProductEO> ProductList { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
