using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class NegativeCountException : ArgumentException
    {
        public NegativeCountException(string message) : base(message) { }
    }
}
