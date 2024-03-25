using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEO = Framework.Entity.Product;
using CategoryEO = Framework.Entity.Category;
namespace Framework.BusinessObj
{
    public class ProductDetails
    {
        public ICollection<ProductEO>? ProductList { get; set; }
        public ICollection<CategoryEO>? CategoryList { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}

