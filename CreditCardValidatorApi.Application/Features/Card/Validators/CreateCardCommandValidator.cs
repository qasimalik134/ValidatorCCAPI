using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

using CreditCardValidatorApi.Application.Features.Card.Commands;

namespace CreditCardValidatorApi.Application.Features.BankType.Validators
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            RuleFor(t => t.CardOwner).NotEmpty().Matches(@"^((?:[A-Za-z]+ ?){1,3})$");
            RuleFor(u => u.CardNumber).NotEmpty().Length(15,19).WithMessage("Invalid Card Number.");
            RuleFor(v => v.IssueDate).NotEmpty().Matches(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$");
            RuleFor(x => x.CVC).NotEmpty().Length(3, 4).WithMessage("Invalid CVC.");
        }
    }
}
