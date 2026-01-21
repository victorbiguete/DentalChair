using DentalChair.Communication.Request;
using DentalChair.Domain.Enum;
using DentalChair.Domain.IRepository;
using DentalChair.Domain.IRepository.Allocation;
using DentalChair.Exceptions;
using DentalChair.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.Allocations.Update.Status
{
    public class UpdateStatusAllocationUseCase : IUpdateStatusAllocationUseCase
    {
        private readonly IReadOnlyAllocationRepository _repositoryRead;
        private readonly IUpdateOnlyAllocationRepository _repositoryUpdate;
        private readonly IUnitofWork _unitofWork;

        public UpdateStatusAllocationUseCase(IReadOnlyAllocationRepository repositoryRead, IUpdateOnlyAllocationRepository repositoryUpdate, IUnitofWork unitofWork)
        {
            _repositoryRead = repositoryRead;
            _repositoryUpdate = repositoryUpdate;
            _unitofWork = unitofWork;
        }

        public async Task Execute(long id, RequestUpdateStatusAllocationJson request)
        {
            Validate(request);
            var allocation = await _repositoryUpdate.GetByIdAsync(id);

            if (allocation is null)
                throw new NotFoundException(ResourceMessagesExceptions.ALLOCATION_NOT_FOUND);

            if((int)allocation.Status != 4)
            allocation.Status = (StatusChair)request.Status;

            _repositoryUpdate.Update(allocation);

            await _unitofWork.Commit();
        }

        private void Validate(RequestUpdateStatusAllocationJson request)
        {
            var validator = new UpdateStatusAllocationValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessage);
            }
        }
    }
}
