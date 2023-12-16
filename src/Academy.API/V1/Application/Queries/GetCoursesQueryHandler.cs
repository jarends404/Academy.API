using Academy.API.Infrastructure.Repositories.Courses;
using Academy.API.Models.Database;
using Academy.API.Models.Responses.Generic;
using MediatR;

namespace Academy.API.V1.Application.Queries;

public class GetCoursesQueryHandler(ICourseRepository courseRepository) : IRequestHandler<GetCoursesQuery, OperationResult<IList<Course>>>
{
    public async Task<OperationResult<IList<Course>>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await courseRepository.GetCourses();

        return courses.Any()
            ? OperationResult<IList<Course>>.Success(courses)
            : OperationResult<IList<Course>>.NotFound();
    }
}