using AutoMapper;
using DentalChair.Communication.Response;
using DentalChair.Domain.IRepository.Allocation;
using DentalChair.Exceptions;
using DentalChair.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.Allocations.GetById
{
    internal class GetByIdUseCase : IGetByIdUseCase
    {
        private readonly IReadOnlyAllocationRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdUseCase(IReadOnlyAllocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseAllocationJson> Execute(long id)
        {
            var allocation = await _repository.GetByIdAsync(id);

            if (allocation is null)
                throw new NotFoundException(ResourceMessagesExceptions.ALLOCATION_NOT_FOUND);

            var response = _mapper.Map<ResponseAllocationJson>(allocation);

            return response;
        }
    }
}
