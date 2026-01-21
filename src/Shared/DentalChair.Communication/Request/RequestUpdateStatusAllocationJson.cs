using DentalChair.Communication.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Communication.Request
{
    public record RequestUpdateStatusAllocationJson
    {
        public StatusChair Status { get; set; }
    }
}
