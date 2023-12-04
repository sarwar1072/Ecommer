using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Exceptions
{
    public class DuplicationException : Exception
    {
       public string DuplicateItemName { get; private set; }
        public DuplicationException(string message,string ItemName) :base(message) 
        {
            DuplicateItemName= ItemName;    
        }
    }
}
