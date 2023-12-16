using Academy.API.Extensions;
using Academy.API.Infrastructure.Repositories.Courses;
using Academy.API.Models.Database;
using Academy.API.Models.Responses.Concrete;
using FluentValidation;
using MediatR;

namespace Academy.API.V1.Application.Commands;

public class PostCourseCommandHandler(
        ICourseRepository courseRepository, 
        IValidator<PostCourseCommand> validator)
    : IRequestHandler<PostCourseCommand, OperationResult>
{
    public async Task<OperationResult> Handle(PostCourseCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return OperationResult.Invalid(validationResult.AsValidationErrors());
        }

        await courseRepository.StoreCourse(new Course
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        });

        return OperationResult.Created();
    }
}