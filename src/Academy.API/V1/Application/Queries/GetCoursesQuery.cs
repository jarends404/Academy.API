using Academy.API.Models.Database;
using Academy.API.Models.Responses.Generic;
using MediatR;

namespace Academy.API.V1.Application.Queries;

public record GetCoursesQuery : IRequest<OperationResult<IList<Course>>>;