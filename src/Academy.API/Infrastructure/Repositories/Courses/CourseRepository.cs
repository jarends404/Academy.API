using Academy.API.Infrastructure.DatabaseContexts;
using Academy.API.Infrastructure.Filters.Courses;
using Academy.API.Models.Database;

namespace Academy.API.Infrastructure.Repositories.Courses;

public class CourseRepository : ICourseRepository
{
    public async Task StoreCourse(Course course)
    {
        await using var context = new CourseContext();
        await context.Courses.AddAsync(course);
        await context.SaveChangesAsync();
    }

    public async Task<IList<Course>> GetCourses()
    {
        await using var context = new CourseContext();
        var list = context.Courses.ToList();
        return list;
    }

    public async Task<IList<Course>> GetCoursesByFilter(ICourseFilter courseFilter)
    {
        await using var context = new CourseContext();
        throw new NotImplementedException();
    }
}