using MediatR;
using TutorApp.Application.Tasks.Dto;

namespace TutorApp.Application.Tasks.Queries
{
    public class GetTaskByIdQuery: IRequest<TaskDto>
    {
        public int Id { get; set; }
    }
}
