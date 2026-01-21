using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Domain.IRepository.Allocation
{
    public interface IUpdateOnlyAllocationRepository
    {
        Task<Entities.Allocation?> GetByIdAsync(long id);
        void Update(Entities.Allocation allocation);
    }
}
