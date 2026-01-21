using DentalChair.Communication.Request;
using DentalChair.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application.UseCases.DentalChairs.Update
{
    public class UpdateDentalChairValidator : AbstractValidator<RequestUpdateChairJson>
    {
        public UpdateDentalChairValidator()
        {
            RuleFor(chair => chair.ChairNumber).NotEmpty().WithMessage(ResourceMessagesExceptions.CHAIR_NUMBER_EMPTY);
            RuleFor(chair => chair.Model).NotEmpty().WithMessage(ResourceMessagesExceptions.MODEL_CHAIR_EMPTY);
            RuleFor(chair => chair.Description).NotEmpty().WithMessage(ResourceMessagesExceptions.DESCRIPTION_CHAIR_EMPTY);
            RuleFor(chair => chair.PurchaseDate).NotEmpty().WithMessage(ResourceMessagesExceptions.PURCHASE_DATE_EMPTY);
        }
    }
}
