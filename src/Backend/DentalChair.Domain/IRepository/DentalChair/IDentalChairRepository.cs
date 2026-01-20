using DentalChair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Domain.IRepository.DentalChair
{
    public interface IDentalChairRepository
    {
        public Task AddAsync(DentalChairs dentalChairs);

        public void Update(DentalChairs dentalChairs);

        public void Delete(DentalChairs dentalChairs);

        public Task<List<DentalChairs>> GetAllChairsActiveAsync();

        public Task<DentalChairs?> GetByIdAsync(long id);

        public Task<DentalChairs?> GetChairByChairNumber(string chairNumber);
    }
}
