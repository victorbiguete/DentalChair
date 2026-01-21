using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Exceptions.ExceptionsBase
{
    public class DentalChairExeceptions : Exception
    {
        public DentalChairExeceptions(string? message) : base(message)
        {
        }
    }
}
