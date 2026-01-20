using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : DentalChairExeceptions
    {
        public ErrorOnValidationException()
        {
        }

        public ErrorOnValidationException(IList<string> message) : base(string.Empty)
        {
        }

        public IList<string> ErrorsMessages { get; set; }

        
    }
}
