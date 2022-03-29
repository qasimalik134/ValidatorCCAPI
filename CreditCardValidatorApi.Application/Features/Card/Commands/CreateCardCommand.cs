using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using CreditCardValidatorApi.Core.Common;

namespace CreditCardValidatorApi.Application.Features.Card.Commands
{
    public class CreateCardCommand : IRequest<Response>
    {
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public string IssueDate { get; set; }
        public string CVC { get; set; }
    }
}
