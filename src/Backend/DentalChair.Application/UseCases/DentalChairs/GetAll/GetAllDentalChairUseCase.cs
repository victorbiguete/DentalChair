using AutoMapper;
using DentalChair.Application.Extensions;
using DentalChair.Communication.Response;
using DentalChair.Domain.IRepository.DentalChair;
using DentalChair.Exceptions;
using DentalChair.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.DentalChairs.GetAll
{
    public class GetAllDentalChairUseCase : IGetAllDentalChairUseCase
    {
        private readonly IDentalChairReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetAllDentalChairUseCase(IDentalChairReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseListDentalChairJson> Execute()
        {
            var dentalChairsList = await _repository.GetAllChairsActiveAsync();

            if (dentalChairsList is null)
                throw new NotFoundException(ResourceMessagesExceptions.CHAIR_NOT_FOUND);

            return new ResponseListDentalChairJson
            {
                DentalChairs = await dentalChairsList.MapToDentalChairJson(_mapper)
            };
        }
    }
}
