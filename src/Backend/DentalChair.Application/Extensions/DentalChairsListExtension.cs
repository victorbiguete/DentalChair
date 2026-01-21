using AutoMapper;
using DentalChair.Communication.Request;
using DentalChair.Communication.Response;
using DentalChair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.Extensions
{
    public static class DentalChairsListExtension
    {
        public static async Task<IList<ResponseDentalChairJson>> MapToDentalChairJson(this IList<DentalChairs> dentalChairs, IMapper mapper)
        {
            var result = dentalChairs.Select(async dentalChairs =>
            {
                var response = mapper.Map<ResponseDentalChairJson>(dentalChairs);
                return response;
            });

            var response = await Task.WhenAll(result);
            return response;
        }
    }
}
