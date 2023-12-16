using Academy.API.Infrastructure.Filters.Courses;
using Academy.API.Models.Database;

namespace Academy.API.Infrastructure.Repositories.Courses;

public interface ICourseRepository
{
    Task StoreCourse(Course course);
    Task<IList<Course>> GetCourses();
    Task<IList<Course>> GetCoursesByFilter(ICourseFilter courseFilter);
}