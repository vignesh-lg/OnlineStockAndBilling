﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventry
{
    class MyException : Exception
    {
        public MyException(string Message) : base(Message)
        {
        }
    }
}
