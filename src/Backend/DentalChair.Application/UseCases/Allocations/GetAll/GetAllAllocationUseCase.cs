using AutoMapper;
using DentalChair.Application.Extensions;
using DentalChair.Communication.Response;
using DentalChair.Domain.IRepository.Allocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.Allocations.GetAll
{
    public class GetAllAllocationUseCase : IGetAllAllocationUseCase
    {
        private readonly IReadOnlyAllocationRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAllocationUseCase(IReadOnlyAllocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseListAllocationJson> Execute()
        {
            var allocation = await _repository.GetAllAllocationAsync();

            return new ResponseListAllocationJson
            {
                Allocations = await allocation.MapToAllocationJson(_mapper)
            };
        }
    }
}
