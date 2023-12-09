using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entity
{
    public class Cover: IEntity<int>
    {
        public int Id { get; set; }
        public string? CoverType { get; set; }
    }
}
