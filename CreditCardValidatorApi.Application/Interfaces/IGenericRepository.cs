using System.Collections.Generic;
using System.Threading.Tasks;
using CreditCardValidatorApi.Core.Common;

namespace CreditCardValidatorApi.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<Response> Add(T entity);
    }
}
