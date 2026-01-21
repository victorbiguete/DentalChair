using AutoMapper;
using DentalChair.Communication.Response;
using DentalChair.Domain.IRepository.DentalChair;
using DentalChair.Exceptions;
using DentalChair.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.DentalChairs.GetById
{
    public class GetByIdDentalChairUseCase : IGetByIdDentalChairUseCase
    {
        private readonly IDentalChairReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdDentalChairUseCase(IDentalChairReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDentalChairJson> Execute(long id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result is null)
                throw new NotFoundException(ResourceMessagesExceptions.CHAIR_NOT_FOUND);

            var response = _mapper.Map<ResponseDentalChairJson>(result);

            return response;
        }
    }
}
