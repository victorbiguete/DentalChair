using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Communication.Request
{
    public record RequestRegisterChairJson
    {
        public string ChairNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
    }
}
