using DentalChair.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.DentalChairs.GetAll
{
    public interface IGetAllDentalChairUseCase
    {
        public Task<ResponseListDentalChairJson> Execute();
    }
}
