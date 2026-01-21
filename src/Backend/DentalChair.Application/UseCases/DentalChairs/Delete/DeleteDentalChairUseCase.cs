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
        private readonly IDentalChairWriteOnlyRepository _repository;
        private readonly IDentalChairReadOnlyRepository _repositoryReadOnly;
        private readonly IUnitofWork _unitofWork;

        public DeleteDentalChairUseCase(IDentalChairWriteOnlyRepository repository, IDentalChairReadOnlyRepository repositoryReadOnly, IUnitofWork unitofWork)
        {
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
            _unitofWork = unitofWork;
        }

        public async Task Execute(long id)
        {
            var dentalChair = await _repositoryReadOnly.GetByIdAsync(id);

            if(dentalChair is null)
            {
                throw new NotFoundException(ResourceMessagesExceptions.CHAIR_NOT_FOUND);
            }

            _repository.Delete(dentalChair);

            await _unitofWork.Commit();
        }
    }
}
