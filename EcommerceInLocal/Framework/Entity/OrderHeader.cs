using DataAccessLayer;
using Framework.Entity.Membership;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entity
{
    public class OrderHeader:IEntity<int>
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime ShippingDate { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
    }
}
