using System.Diagnostics.CodeAnalysis;
using Academy.API.Models.Responses.Concrete;
using Academy.API.V1.Controllers.Base;
using Academy.API.V2.Application.Commands;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Academy.API.V2.Controllers;

[ExcludeFromCodeCoverage]
[ApiVersion(2.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class CourseController(IMediator mediator) : BaseController
{
    [HttpPost]
    [SwaggerOperation("", "Creates a new course")]
    public async Task<OperationResult> Post([FromBody] PostCourseCommand command)
    {
        return await mediator.Send(command);
    }
}