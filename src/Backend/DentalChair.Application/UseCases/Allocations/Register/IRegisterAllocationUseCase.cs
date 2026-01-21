using DentalChair.Communication.Request;
using DentalChair.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.Allocations.Register
{
    public interface IRegisterAllocationUseCase
    {
        Task<ResponseAllocationJson> Execute(RequestRegisterAllocationJson request);
    }
}
