using MediatR;
using System.Collections.Generic;
using TutorApp.Application.Tasks.Dto;

namespace TutorApp.Application.Tasks.Queries
{
    public class GetAllTasksQuery: IRequest<List<TaskDto>>
    {
    }
}
