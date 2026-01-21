using DentalChair.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.DentalChairs.GetById
{
    public interface IGetByIdDentalChairUseCase
    {
        public Task<ResponseDentalChairJson> Execute(long id);
    }
}
