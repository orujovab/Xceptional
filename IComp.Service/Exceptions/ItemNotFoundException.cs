using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string msg) : base(msg)
        {

        }
    }
}
