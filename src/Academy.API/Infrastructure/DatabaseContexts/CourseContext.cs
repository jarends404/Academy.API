using Academy.API.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Academy.API.Infrastructure.DatabaseContexts;

public class CourseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "AcademyDb");
    }

    public DbSet<Course> Courses { get; set; }
}