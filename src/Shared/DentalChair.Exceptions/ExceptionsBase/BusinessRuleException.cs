using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Exceptions.ExceptionsBase
{
    public class BusinessRuleException : DentalChairExeceptions
    {
        public BusinessRuleException(string? message) : base(message)
        {
            
        }
    }
}
