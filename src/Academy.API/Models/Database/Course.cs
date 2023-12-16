using System.ComponentModel.DataAnnotations;

namespace Academy.API.Models.Database;

public class Course
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int MaximumParticipants { get; set; }
    public int StudyInvestmentInHours { get; set; }
}