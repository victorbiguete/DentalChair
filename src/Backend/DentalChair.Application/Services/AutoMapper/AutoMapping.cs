using AutoMapper;
using DentalChair.Communication.Request;
using DentalChair.Communication.Response;
using DentalChair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
            DomainToResponse();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterChairJson, DentalChairs>();
            CreateMap<RequestRegisterAllocationJson, Allocation>();
        }

        private void DomainToResponse()
        {
            CreateMap<DentalChairs, ResponseRegisteredChairJson>();
            CreateMap<DentalChairs, ResponseListDentalChairJson>();
            CreateMap<DentalChairs, ResponseDentalChairJson>();
            CreateMap<Allocation, ResponseAllocationJson>();
            CreateMap<Allocation, ResponseListAllocationJson>();
        }
    }
}
