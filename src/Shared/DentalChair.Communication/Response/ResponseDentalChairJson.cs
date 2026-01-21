using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Communication.Response
{
    public record ResponseDentalChairJson
    {
        public string ChairNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public DateTime LastMaintenance { get; set; }
        public int UsageCount { get; set; } = 0;
    }
}
