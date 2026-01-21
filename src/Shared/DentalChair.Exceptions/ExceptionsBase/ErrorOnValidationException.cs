using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : DentalChairExeceptions
    {
        
        public ErrorOnValidationException(IList<string> message) : base(string.Empty)
        {
            ErrorsMessages = message;
        }

        public IList<string> ErrorsMessages { get; set; }
    }
}
