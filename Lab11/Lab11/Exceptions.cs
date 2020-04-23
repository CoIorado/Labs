using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message) { }
    }
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string message) : base(message) { }
    }
    public class InvalidLastNameException : Exception
    {
        public InvalidLastNameException(string message) : base(message) { }
    }
    public class InvalidUniversityException : Exception
    {
        public InvalidUniversityException(string message) : base(message) { }
    }
    public class InvalidSalaryException : Exception
    {
        public InvalidSalaryException(string message) : base(message) { }
    }
    public class InvalidGroupException : Exception
    {
        public InvalidGroupException(string message) : base(message) { }
    }
    public class InvalidGenderException : Exception
    {
        public InvalidGenderException(string message) : base(message) { }
    }
}
