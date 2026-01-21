using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Communication.Response
{
    public class ResponseListAllocationJson
    {
        public IList<ResponseAllocationJson> Allocations { get; set; } = [];
    }
}
