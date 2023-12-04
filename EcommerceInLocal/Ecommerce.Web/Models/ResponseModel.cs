using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Models
{
    public class ResponseModel
    {
        public string Message { set; get; }
        public ResponseType Type { get; set; }

    }
}
