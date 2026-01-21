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

namespace DentalChair.Application.UseCases.DentalChairs.GetChairByChairNumber
{
    public class GetByChairNumberUseCase : IGetByChairNumberUseCase
    {
        private readonly IDentalChairReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetByChairNumberUseCase(IDentalChairReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDentalChairJson> Execute(string chairNumber)
        {
            var result = await _repository.GetChairByChairNumber(chairNumber);

            if(result is null)
                throw new NotFoundException(ResourceMessagesExceptions.CHAIR_NOT_FOUND);

            var response = _mapper.Map<ResponseDentalChairJson>(result);

            return response;
        }
    }
}
