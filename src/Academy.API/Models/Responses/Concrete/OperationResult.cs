using Academy.API.Models.Responses.Base;
using Academy.API.Models.Responses.Generic;

namespace Academy.API.Models.Responses.Concrete;

public class OperationResult : OperationResult<OperationResult>
{
    public static OperationResult Created() => new()
    {
        ResultStatus = ResultStatus.Created
    };

    public static OperationResult Invalid(List<ValidationError> validationErrors) => new()
    {
        ResultStatus = ResultStatus.Invalid,
        ValidationErrors = validationErrors
    };
}