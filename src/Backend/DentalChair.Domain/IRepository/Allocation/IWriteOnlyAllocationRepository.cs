using DentalChair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Domain.IRepository.Allocation
{
    public interface IWriteOnlyAllocationRepository
    {
        Task AddAsync(Entities.Allocation allocation);
        void Delete(Entities.Allocation allocation);
    }
}
