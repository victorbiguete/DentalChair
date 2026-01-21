using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.DentalChairs.Delete
{
    public interface IDeleteDentalChairUseCase
    {
        public Task Execute(long id);
    }
}
