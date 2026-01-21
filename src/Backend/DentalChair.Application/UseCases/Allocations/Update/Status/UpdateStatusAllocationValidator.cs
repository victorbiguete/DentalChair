using DentalChair.Communication.Request;
using DentalChair.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.Allocations.Update.Status
{
    public class UpdateStatusAllocationValidator : AbstractValidator<RequestUpdateStatusAllocationJson>
    {
        public UpdateStatusAllocationValidator()
        {
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage(ResourceMessagesExceptions.STATUS_ALLOCATION_EMPTY)
                .IsInEnum().WithMessage(ResourceMessagesExceptions.STATUS_ALLOCATION_NOT_SUPPORTED);
        }
    }
}
