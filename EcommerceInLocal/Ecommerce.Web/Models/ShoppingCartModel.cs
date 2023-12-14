using Framework.BusinessObj;

namespace Ecommerce.Web.Models
{
    public class ShoppingCartModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public ShoppingCartModel()
        {
                Count = 1;  
        }
    }
}






















