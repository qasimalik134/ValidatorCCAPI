using AutoMapper;
using TutorApp.Application.Tasks.Commands;
using TutorApp.Application.Tasks.Dto;
using TutorApp.Core.Entities;

namespace TutorApp.Application.Tasks.MappingProfiles
{
    public class TaskMappingProfile: Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<CreateTaskCommand, Task>();
            CreateMap<UpdateTaskCommand, Task>();
            CreateMap<Task, TaskDto>();
        }
    }
}
