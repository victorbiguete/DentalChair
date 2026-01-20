using DentalChair.Domain.Entities;
using DentalChair.Domain.IRepository.DentalChair;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Infrastructure.DataAccess.Repositories.DentalChair
{
    public class DentalChairRepository : IDentalChairRepository
    {
        private readonly AppDbContext _context;

        public DentalChairRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DentalChairs dentalChairs) => await _context.AddAsync(dentalChairs);

        public void Update(DentalChairs dentalChairs) => _context.DentalChairs.Update(dentalChairs);

        public void Delete(DentalChairs dentalChairs) => _context.DentalChairs.Remove(dentalChairs);

        public async Task<List<DentalChairs>> GetAllChairsActiveAsync() => await _context.DentalChairs.Where(c => c.Active).ToListAsync();

        public async Task<DentalChairs?> GetByIdAsync(long id) => await _context.DentalChairs.Where(c => c.Active && c.Id == id).FirstOrDefaultAsync();

        public async Task<DentalChairs?> GetChairByChairNumber(string chairNumber) => await _context.DentalChairs.Where(c => c.Active && c.ChairNumber.Equals(chairNumber)).FirstOrDefaultAsync();
    }
}
