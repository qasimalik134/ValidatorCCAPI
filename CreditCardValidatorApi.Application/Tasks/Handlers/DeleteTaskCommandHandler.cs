using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TutorApp.Application.Interfaces;
using TutorApp.Application.Tasks.Commands;

namespace TutorApp.Application.Tasks.Handlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Tasks.Delete(request.Id);
            return result;
        }
    }
}
