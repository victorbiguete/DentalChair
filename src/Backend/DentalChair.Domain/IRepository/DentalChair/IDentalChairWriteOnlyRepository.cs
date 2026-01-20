using DentalChair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Domain.IRepository.DentalChair
{
    public interface IDentalChairWriteOnlyRepository
    {
        public Task AddAsync(DentalChairs dentalChairs);
        public void Delete(DentalChairs dentalChairs);
    }
}
