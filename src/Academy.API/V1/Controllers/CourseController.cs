using System.Diagnostics.CodeAnalysis;
using System.Net;
using Academy.API.Models.Database;
using Academy.API.Models.Responses.Concrete;
using Academy.API.Models.Responses.Generic;
using Academy.API.V1.Application.Commands;
using Academy.API.V1.Application.Queries;
using Academy.API.V1.Controllers.Base;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Academy.API.V1.Controllers;

[ExcludeFromCodeCoverage]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class CourseController(IMediator mediator) : BaseController
{
    [HttpPost]
    [SwaggerOperation("", "Creates a new course")]
    [ProducesResponseType(typeof(OperationResult), (int) HttpStatusCode.Created)]
    [ProducesResponseType(typeof(OperationResult), (int) HttpStatusCode.BadRequest)]
    public async Task<OperationResult> Post([FromBody] PostCourseCommand command)
    {
        return await mediator.Send(command);
    }
    
    [HttpGet]
    [SwaggerOperation("", "Returns a list of all courses")]
    [ProducesResponseType(typeof(OperationResult<IList<Course>>), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(OperationResult<IList<Course>>), (int) HttpStatusCode.NotFound)]
    public async Task<OperationResult<IList<Course>>> Get()
    {
        return await mediator.Send(new GetCoursesQuery());
    }
}