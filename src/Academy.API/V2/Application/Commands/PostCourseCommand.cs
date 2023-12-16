using Academy.API.Models.Responses.Concrete;
using MediatR;

namespace Academy.API.V2.Application.Commands;

public record PostCourseCommand : IRequest<OperationResult>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int MaximumParticipants { get; set; }
    public int StudyInvestmentInHours { get; set; }
}