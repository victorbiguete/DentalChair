using DentalChair.Domain.Enum;
using DentalChair.Domain.IRepository.Allocation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Infrastructure.DataAccess.Repositories.Allocation
{
    public class AllocationRepository : IReadOnlyAllocationRepository, IWriteOnlyAllocationRepository, IUpdateOnlyAllocationRepository
    {
        private readonly AppDbContext _context;

        public AllocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Entities.Allocation allocation) => await _context.Allocations.AddAsync(allocation);

        public void Delete(Domain.Entities.Allocation allocation) => _context.Allocations.Remove(allocation);

        public async Task<IList<Domain.Entities.Allocation>> GetAllAllocationAsync() => await _context.Allocations.AsNoTracking().Where(a => a.Active).ToListAsync();

        public async Task<IList<Domain.Entities.Allocation>> GetByDateRangeAsync(DateTime start, DateTime end) => await _context.Allocations.AsNoTracking().Where(a => a.Active && a.StartDate >= start && a.EndDate <= end).ToListAsync();

        public async Task<Domain.Entities.Allocation?> GetByDentalChairIdAsync(long id) => await _context.Allocations.AsNoTracking().Where(a => a.DentalChairId == id).FirstOrDefaultAsync();

        public async Task<IList<Domain.Entities.Allocation>> GetByPatienceNameAsync(string patientName) => await _context.Allocations.AsNoTracking().Where(a => a.PatientName.Equals(patientName)).ToListAsync();

        async Task<Domain.Entities.Allocation?> IReadOnlyAllocationRepository.GetByIdAsync(long id) => await _context.Allocations.AsNoTracking().Where(a => a.Id == id).FirstOrDefaultAsync();

        async Task<Domain.Entities.Allocation?> IUpdateOnlyAllocationRepository.GetByIdAsync(long id) => await _context.Allocations.Where(a => a.Id == id).FirstOrDefaultAsync();

        public void Update(Domain.Entities.Allocation allocation) => _context.Allocations.Update(allocation);
        public async Task<bool> IsChairAvailableAsync(long id, DateTime start, DateTime end)
        {
            var hasConflict = await _context.Allocations
                .Where(a => a.DentalChairId == id)
                .Where(a => a.Status != StatusChair.Cancelled)
                .AnyAsync(a =>
                    a.StartDate <= end &&   // A alocação existente começa antes do término solicitado
                    a.EndDate >= start      // E termina depois do início solicitado
                );

            return hasConflict;
        }

        public async Task<IList<long>> GetChairsByDateAsync(DateTime start) => 
            await _context.Allocations.AsNoTracking()
            .Where(a => a.Active 
            && a.StartDate <= start && a.EndDate >= start)
            .Select(a => a.DentalChairId)
            .Distinct().ToListAsync();
    }
}
