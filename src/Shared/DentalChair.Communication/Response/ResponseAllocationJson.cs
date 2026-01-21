using DentalChair.Communication.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Communication.Response
{
    public class ResponseAllocationJson
    {
        public long DentalChairId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PatientName { get; set; } 
        public string ProcedureType { get; set; } 
        public StatusChair Status { get; set; } 
    }
}
