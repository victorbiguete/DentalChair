using AutoMapper;
using DentalChair.Application.UseCases.DentalChairs.Update;
using DentalChair.Communication.Request;
using DentalChair.Communication.Response;
using DentalChair.Domain.Entities;
using DentalChair.Domain.IRepository;
using DentalChair.Domain.IRepository.Allocation;
using DentalChair.Domain.IRepository.DentalChair;
using DentalChair.Exceptions;
using DentalChair.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.Allocations.Register
{
    public class RegisterAllocationUseCase : IRegisterAllocationUseCase
    {
        private readonly IWriteOnlyAllocationRepository _repositoryWrite;
        private readonly IReadOnlyAllocationRepository _repositoryRead;
        private readonly IDentalChairReadOnlyRepository _repositoryDentalRead;
        private readonly IUpdateDentalChairUseCase _useCaseUpdate;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;

        public RegisterAllocationUseCase(IWriteOnlyAllocationRepository repositoryWrite, IReadOnlyAllocationRepository repositoryRead, IDentalChairReadOnlyRepository repositoryDentalRead, IUpdateDentalChairUseCase useCaseUpdate, IMapper mapper, IUnitofWork unitofWork)
        {
            _repositoryWrite = repositoryWrite;
            _repositoryRead = repositoryRead;
            _repositoryDentalRead = repositoryDentalRead;
            _useCaseUpdate = useCaseUpdate;
            _mapper = mapper;
            _unitofWork = unitofWork;
        }

        public async Task<ResponseAllocationJson> Execute(RequestRegisterAllocationJson request)
        {
            Validate(request);

            var availableChair = await GetAvailableChairsAsync(request.StartDate, request.EndDate);

            if (!availableChair.Any())
                throw new BusinessRuleException(ResourceMessagesExceptions.NO_CHAIRS_AVAILABLE);

            var selectChair = SelectAvailableChair(availableChair,request);

            var allocation = _mapper.Map<Allocation>(request);

            allocation.DentalChairId = selectChair!.Id;

            await _repositoryWrite.AddAsync(allocation);

            await _useCaseUpdate.IncrementUsageCount(selectChair!.Id);

            await _unitofWork.Commit();

            return _mapper.Map<ResponseAllocationJson>(allocation);
        }

        private async Task<IList<Domain.Entities.DentalChairs>> GetAvailableChairsAsync(DateTime start, DateTime end)
        {
            var activeChairs = await _repositoryDentalRead.GetAllChairsActiveAsync();

            var availableChairs = new List<Domain.Entities.DentalChairs>();

            foreach (var chair in activeChairs)
            {
                // Verificar se a cadeira está disponível no período
                var isAvailable = await _repositoryRead.IsChairAvailableAsync(
                    chair.Id, start, end);

                if (!isAvailable)
                {
                    availableChairs.Add(chair);
                }
            }

            return availableChairs;
        }

        private Domain.Entities.DentalChairs SelectAvailableChair(IList<Domain.Entities.DentalChairs> availableChair, RequestRegisterAllocationJson request)
        {
            var selectChair = new Domain.Entities.DentalChairs();

            if (request.DentalChairId == 0)
                selectChair = availableChair.OrderBy(x => x.UsageCount).First();
            else if (availableChair.Count() > 0)
                selectChair = availableChair.FirstOrDefault(x => x.Id == request.DentalChairId);
            
            if(selectChair is null)
                throw new NotFoundException(ResourceMessagesExceptions.NO_CHAIRS_AVAILABLE);

            return selectChair!;
        }

        private void Validate(RequestRegisterAllocationJson request)
        {
            var validator = new RegisterAllocationValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessage);
            }
        }
    }
}
