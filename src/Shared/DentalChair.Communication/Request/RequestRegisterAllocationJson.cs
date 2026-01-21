using DentalChair.Communication.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Communication.Request
{
    public class RequestRegisterAllocationJson
    {
        public long DentalChairId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string ProcedureType { get; set; } = string.Empty;
        public StatusChair Status { get; set; } = StatusChair.Scheduled;
    }
}
