using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Communication.Request
{
    public record RequestChairAvailableByDate
    {
        public DateTime DateStart { get; set; }
    }
}
