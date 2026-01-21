using DentalChair.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.DentalChairs.Update
{
    public interface IUpdateDentalChairUseCase
    {
        public Task Execute(RequestUpdateChairJson request, long id);
        public Task UpdateMaintenance(long id, DateTime maintenanceDate);
        public Task IncrementUsageCount(long id);
    }
}
