using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Exceptions
{
    public class DuplicationException2:Exception
    {
        public string DuplicateItemName { get; set; }
        public DuplicationException2(string message, string itemName) : base(message)
        {
            DuplicateItemName = itemName;
        }
    }
}
