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
        public DateTime PurchaseDate { get; set; }
        public DateTime LastMaintenance { get; set; }

        public virtual ICollection<> Allocations { get; set; }
    }
}
