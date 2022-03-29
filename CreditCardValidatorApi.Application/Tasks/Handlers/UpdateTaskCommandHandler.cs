using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TutorApp.Application.Interfaces;
using TutorApp.Application.Tasks.Commands;

namespace TutorApp.Application.Tasks.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Tasks.Update(_mapper.Map<TutorApp.Core.Entities.Task>(request));
            return result;
        }
    }
}
