using DentalChair.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.Allocations.GetById
{
    public interface IGetByIdUseCase
    {
        Task<ResponseAllocationJson> Execute(long id);
    }
}
