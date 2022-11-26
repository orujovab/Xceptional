using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.Exceptions
{
    public class RecordDuplicatedException : Exception
    {
        public RecordDuplicatedException(string msg) : base(msg)
        {

        }
    }
}
