using DentalChair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Domain.IRepository.Allocation
{
    public interface IReadOnlyAllocationRepository
    {
        Task<Entities.Allocation?> GetByIdAsync(long id);
        Task<Entities.Allocation?> GetByDentalChairIdAsync(long id);
        Task<IList<Entities.Allocation>> GetAllAllocationAsync();
        Task<IList<Entities.Allocation>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task<IList<Entities.Allocation>> GetByPatienceNameAsync(string patientName);
        //Task<bool> IsChairAvailableAsync();
    }
}