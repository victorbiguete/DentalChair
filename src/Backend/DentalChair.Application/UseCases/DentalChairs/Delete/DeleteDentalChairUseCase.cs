using DentalChair.Domain.IRepository;
using DentalChair.Domain.IRepository.DentalChair;
using DentalChair.Exceptions;
using DentalChair.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.DentalChairs.Delete
{
    public class DeleteDentalChairUseCase : IDeleteDentalChairUseCase
    {
        private readonly IDentalChairUpdateOnlyRepository _repository;
        private readonly IUnitofWork _unitofWork;

        public DeleteDentalChairUseCase(IDentalChairUpdateOnlyRepository repository, IUnitofWork unitofWork)
        {
            _repository = repository;
            _unitofWork = unitofWork;
        }

        public async Task Execute(long id)
        {
            var dentalChair = await _repository.GetByIdAsync(id);

            if(dentalChair is null)
            {
                throw new NotFoundException(ResourceMessagesExceptions.CHAIR_NOT_FOUND);
            }

            dentalChair.Active = false;

            _repository.Update(dentalChair);

            await _unitofWork.Commit();
        }
    }
}
