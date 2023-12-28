using DataAccessLayer;
using Framework.Entity.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entity
{
    public class ShoppingCart:IEntity<int>
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public Guid ApplicationUserId { get; set; }
        [NotMapped]
        public ApplicationUser ApplicationUser { get; set; }

        //public ShoppingCart()
        //{
        //    Count = 1;
        //}
    }
}
