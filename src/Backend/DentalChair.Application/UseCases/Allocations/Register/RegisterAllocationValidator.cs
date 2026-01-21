using DentalChair.Communication.Request;
using DentalChair.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.Allocations.Register
{
    public class RegisterAllocationValidator : AbstractValidator<RequestRegisterAllocationJson>
    {
        public RegisterAllocationValidator()
        {
            RuleFor(x => x.PatientName)
                .NotEmpty().WithMessage(ResourceMessagesExceptions.PATIENT_NAME_EMPTY)
                .MaximumLength(200).WithMessage(ResourceMessagesExceptions.PATIENT_NAME_MAX_LENGHT);

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage(ResourceMessagesExceptions.STAR_DATE_EMPTY)
                .GreaterThan(DateTime.UtcNow).WithMessage(ResourceMessagesExceptions.STAR_DATE_GREATER_THAN);

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage(ResourceMessagesExceptions.END_DATE_EMPTY)
                .GreaterThan(x => x.StartDate).WithMessage(ResourceMessagesExceptions.END_DATE_GREATER_THAN);

            RuleFor(x => x.ProcedureType)
                .NotEmpty().WithMessage(ResourceMessagesExceptions.PROCEDURE_TYPE_EMPTY)
                .MaximumLength(100).WithMessage(ResourceMessagesExceptions.PROCEDURE_TYPE_MAX_LENGHT);
        }
    }
}
