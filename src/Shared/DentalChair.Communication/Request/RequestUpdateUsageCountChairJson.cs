using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Communication.Request
{
    public record RequestUpdateUsageCountChairJson
    {
        public long Id { get; set; }
        public int UsageCount { get; set; }
    }
}
