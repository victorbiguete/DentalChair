using DentalChair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Domain.IRepository.DentalChair
{
    public interface IDentalChairUpdateOnlyRepository
    {
        public Task<DentalChairs?> GetByIdAsync(long id);
        public Task<DentalChairs?> GetChairByChairNumber(string chairNumber);
        public void Update(DentalChairs dentalChairs);
    }
}
