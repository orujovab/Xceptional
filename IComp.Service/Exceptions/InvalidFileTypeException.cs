using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.Exceptions
{
    public class InvalidFileTypeException : Exception
    {
        public InvalidFileTypeException(string msg) : base(msg)
        {

        }
    }
}
