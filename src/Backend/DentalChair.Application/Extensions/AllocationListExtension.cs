using AutoMapper;
using DentalChair.Communication.Response;
using DentalChair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.Extensions
{
    public static class AllocationListExtension
    {
        public static async Task<IList<ResponseAllocationJson>> MapToAllocationJson(this IList<Allocation> allocations, IMapper mapper)
        {
            var result = allocations.Select(async allocations =>
            {
                var response = mapper.Map<ResponseAllocationJson>(allocations);
                return response;
            });

            var response = await Task.WhenAll(result);
            return response;
        }
    }
}
