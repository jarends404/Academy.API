using Academy.API.Extensions;
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
            .MustBeValidDate()
            .WithMessage("Start date must be a valid date")
            .MustBeInTheFuture()
            .WithMessage("Start date must be in the future");
        RuleFor(command => command.EndDate)
            .NotEmpty()
            .MustBeValidDate()
            .WithMessage("End date must be a valid date")
            .MustBeInTheFuture()
            .WithMessage("End date must be in the future");
    }
}