using DentalChair.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.Allocations.Update.Status
{
    public interface IUpdateStatusAllocationUseCase
    {
        Task Execute(long id, RequestUpdateStatusAllocationJson request);
    }
}
