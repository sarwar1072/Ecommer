﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Exceptions
{
    public class InvalidCreationException:Exception
    {
        public InvalidCreationException(string message):base(message)
        {
        }
    }
}
