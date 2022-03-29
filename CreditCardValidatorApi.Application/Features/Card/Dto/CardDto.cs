using System;
using System.Collections.Generic;
using System.Text;
using CreditCardValidatorApi.Core.Enums;

namespace CreditCardValidatorApi.Application.Features.Card.Dto
{
    public class CardDto
    {
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public string IssueDate { get; set; }
        public string CVC { get; set; }
    }
}
