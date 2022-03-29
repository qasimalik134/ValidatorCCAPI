using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CreditCardValidatorApi.Application.Features.Card.Commands;
using CreditCardValidatorApi.Application.Interfaces;
using CreditCardValidatorApi.Core.Common;

namespace CreditCardValidatorApi.Application.Features.BankType.Handlers
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Card.Add(_mapper.Map<CreditCardValidatorApi.Core.Entities.Card>(request));
            return result;
        }
    }
}
