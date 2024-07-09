using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entity
{
    public class Seller : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
    }
}
