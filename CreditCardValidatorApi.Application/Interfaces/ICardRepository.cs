using System;
using System.Collections.Generic;
using System.Text;
using CreditCardValidatorApi.Core.Entities;

namespace CreditCardValidatorApi.Application.Interfaces
{
    public interface ICardRepository : IGenericRepository<Card>
    {
    }
}
