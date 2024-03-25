using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEO = Framework.Entity.Category;
using ProductEO = Framework.Entity.Product;

namespace Framework.BusinessObj
{
    public class DisplayCategory
    {
        public int DisplayId { get; set; }
        public IQueryable<CategoryEO>? CategoryList { get; set; }
        public IQueryable<ProductEO>? ProductList { get; set; }
        public string?  SearchCategory { get; set; }

    }
}
