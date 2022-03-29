using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CreditCardValidatorApi.Core.Common;

namespace CreditCardValidatorApi.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Response>
    where TRequest : IRequest<Response>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        /*
         Responsible for returning Validation Message(s)
         */
        public Task<Response> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Response> next)
        {
            var context = new ValidationContext(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                Response response = new Response();
                
                response.ErrorMessages = new List<Error>();
                response.Status = "Validation Error(s).";
                response.Data = "";
                foreach (var failure in failures)
                {
                    Error error = new Error();
                    error.PropertyName = failure.PropertyName;
                    error.Message = failure.ErrorMessage;
                    response.ErrorMessages.Add(error);
                }
                return Task.FromResult(response);
            }
            else
            {
                return next();
            }
        }
    }

}
