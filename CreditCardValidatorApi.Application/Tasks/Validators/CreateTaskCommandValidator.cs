﻿using FluentValidation;
using TutorApp.Application.Tasks.Commands;

namespace TutorApp.Application.Tasks.Validators
{
    public class CreateTaskCommandValidator: AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Description).NotEmpty();
            RuleFor(t => t.Status).NotNull();
            RuleFor(t => t.DueDate).NotNull();
        }
    }
}
