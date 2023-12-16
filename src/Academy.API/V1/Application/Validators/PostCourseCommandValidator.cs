using Academy.API.V1.Application.Commands;
using FluentValidation;

namespace Academy.API.V1.Application.Validators;

public class PostCourseCommandValidator : AbstractValidator<PostCourseCommand>
{
    public PostCourseCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage("Description is required");
        RuleFor(command => command.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required");
        RuleFor(command => command.EndDate)
            .NotEmpty()
            .WithMessage("End date is required");
    }
}