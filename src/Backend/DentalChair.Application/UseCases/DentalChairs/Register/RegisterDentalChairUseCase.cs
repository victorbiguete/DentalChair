using AutoMapper;
using DentalChair.Communication.Request;
using DentalChair.Communication.Response;
using DentalChair.Domain.Entities;
using DentalChair.Domain.IRepository;
using DentalChair.Domain.IRepository.DentalChair;
using DentalChair.Exceptions;
using DentalChair.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.DentalChairs.Register
{
    public class RegisterDentalChairUseCase : IRegisterDentalChairUseCase
    {
        private readonly IDentalChairWriteOnlyRepository _writeRepository;
        private readonly IDentalChairReadOnlyRepository _readRepository;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;

        public RegisterDentalChairUseCase(IDentalChairWriteOnlyRepository writeRepository, IDentalChairReadOnlyRepository readRepository, IMapper mapper, IUnitofWork unitofWork)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
            _unitofWork = unitofWork;
        }

        public async Task<ResponseRegisteredChairJson> Execute(RequestRegisterChairJson request)
        {
            await Validate(request);

            var chair = _mapper.Map<Domain.Entities.DentalChairs>(request);

            await _writeRepository.AddAsync(chair);

            await _unitofWork.Commit();

            return new ResponseRegisteredChairJson
            {
                ChairNumber = request.ChairNumber,
                Description = request.Description,
                Model = request.Model,
                PurchaseDate = request.PurchaseDate
            };
        }

        private async Task Validate(RequestRegisterChairJson request)
        {
            var validator = new RegisterDentalChairValidator();

            var result = await validator.ValidateAsync(request);

            var charNumberExist = await _readRepository.GetChairByChairNumber(request.ChairNumber);

            if(charNumberExist != null)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesExceptions.CHAIR_NUMBER_ALREADY_REGISTERED));
            }

            if(!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
