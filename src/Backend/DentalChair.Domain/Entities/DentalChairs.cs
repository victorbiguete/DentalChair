using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Domain.Entities
{
    public class DentalChairs : EntityBase
    {
        public string ChairNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public DateTime LastMaintenance { get; set; } = DateTime.UtcNow;
        public int UsageCount { get; set; } = 0;

    }
}
