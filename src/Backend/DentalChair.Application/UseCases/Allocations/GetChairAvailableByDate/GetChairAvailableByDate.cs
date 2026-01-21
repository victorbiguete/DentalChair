using AutoMapper;
using DentalChair.Application.Extensions;
using DentalChair.Communication.Request;
using DentalChair.Communication.Response;
using DentalChair.Domain.IRepository.Allocation;
using DentalChair.Domain.IRepository.DentalChair;
using DentalChair.Exceptions;
using DentalChair.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.Allocations.GetChairAvailableByDate
{
    public class GetChairAvailableByDate : IGetChairAvailableByDate
    {
        private readonly IDentalChairReadOnlyRepository _repositoryReadChair;
        private readonly IReadOnlyAllocationRepository _repositoryReadAllocation;
        private readonly IMapper _mapper;

        public GetChairAvailableByDate(IDentalChairReadOnlyRepository repositoryReadChair, IReadOnlyAllocationRepository repositoryReadAllocation, IMapper mapper)
        {
            _repositoryReadChair = repositoryReadChair;
            _repositoryReadAllocation = repositoryReadAllocation;
            _mapper = mapper;
        }

        public async Task<ResponseListDentalChairJson> Execute(DateTime date)
        {
            var allocationList = await _repositoryReadAllocation.GetChairsByDateAsync(date);

            if (allocationList is null || allocationList.Count == 0)
                throw new BusinessRuleException(ResourceMessagesExceptions.CHAIR_NOT_FOUND);

            var chairsList = await _repositoryReadChair.GetAllChairsActiveAsync();

            var chairsAvailable = chairsList.Where(x => !allocationList.Contains(x.Id)).ToList();

            return new ResponseListDentalChairJson
            {
                DentalChairs = await chairsAvailable.MapToDentalChairJson(_mapper)
            };
        }
    }
}
