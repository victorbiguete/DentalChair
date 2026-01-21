using AutoMapper;
using DentalChair.Communication.Request;
using DentalChair.Domain.IRepository;
using DentalChair.Domain.IRepository.DentalChair;
using DentalChair.Exceptions;
using DentalChair.Exceptions.ExceptionsBase;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.DentalChairs.Update
{
    public class UpdateDentalChairUseCase : IUpdateDentalChairUseCase
    {
        private readonly IDentalChairUpdateOnlyRepository _repositoryUpdate;
        private readonly IDentalChairReadOnlyRepository _repositoryRead;
        private readonly IUnitofWork _unitofWork;

        public UpdateDentalChairUseCase(IDentalChairUpdateOnlyRepository repositoryUpdate, IDentalChairReadOnlyRepository repositoryRead, IUnitofWork unitofWork)
        {
            _repositoryUpdate = repositoryUpdate;
            _repositoryRead = repositoryRead;
            _unitofWork = unitofWork;
        }

        public async Task Execute(RequestUpdateChairJson request,long id)
        {
            await Validate(request, id);

            var dentalChair = await _repositoryUpdate.GetByIdAsync(id);

            if(dentalChair is null)
            {
                throw new NotFoundException(ResourceMessagesExceptions.CHAIR_NOT_FOUND);
            }

            dentalChair.PurchaseDate = request.PurchaseDate;
            dentalChair.ChairNumber = request.ChairNumber;
            dentalChair.Description = request.Description;
            dentalChair.Model = request.Model;
            dentalChair.UpdatedAt = DateTime.UtcNow;

            _repositoryUpdate.Update(dentalChair);

            await _unitofWork.Commit();
        }

        public async Task IncrementUsageCount(long id)
        {
            var dentalChair = await _repositoryUpdate.GetByIdAsync(id);

            if (dentalChair is null)
            {
                throw new NotFoundException(ResourceMessagesExceptions.CHAIR_NOT_FOUND);
            }

            dentalChair.UsageCount++;
            dentalChair.UpdatedAt = DateTime.UtcNow;

            _repositoryUpdate.Update(dentalChair);

            await _unitofWork.Commit();
        }

        public async Task UpdateMaintenance(long id, DateTime maintenanceDate)
        {
            var dentalChair = await _repositoryUpdate.GetByIdAsync(id);

            if (dentalChair is null)
            {
                throw new NotFoundException(ResourceMessagesExceptions.CHAIR_NOT_FOUND);
            }

            dentalChair.LastMaintenance = maintenanceDate;
            dentalChair.UpdatedAt = DateTime.UtcNow;

            _repositoryUpdate.Update(dentalChair);

            await _unitofWork.Commit();
        }

        private async Task Validate(RequestUpdateChairJson request, long id)
        {
            var validator = new UpdateDentalChairValidator();
            var result = await validator.ValidateAsync(request);

            var dentalChair = await _repositoryRead.GetChairByChairNumber(request.ChairNumber);

            if (dentalChair is not null && dentalChair.Id != id)
            {
                result.Errors.Add(new ValidationFailure("chair", ResourceMessagesExceptions.CHAIR_NUMBER_ALREADY_EXIST_IN_OTHER_CHAIR));
            }
            
            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
