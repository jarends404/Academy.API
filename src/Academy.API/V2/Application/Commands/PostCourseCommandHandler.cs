using Academy.API.Infrastructure.Repositories.Courses;
using Academy.API.Models.Database;
using Academy.API.Models.Responses.Concrete;
using MediatR;

namespace Academy.API.V2.Application.Commands;

public class PostCourseCommandHandler(ICourseRepository courseRepository) : IRequestHandler<PostCourseCommand, OperationResult>
{
    public async Task<OperationResult> Handle(PostCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            MaximumParticipants = request.MaximumParticipants,
            StudyInvestmentInHours = request.StudyInvestmentInHours
        };

        await courseRepository.StoreCourse(course);

        return OperationResult.Created();
    }
}