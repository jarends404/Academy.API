using Academy.API.Models.Responses.Base;
using Academy.API.Models.Responses.Generic;

namespace Academy.API.Models.Responses.Concrete;

public class OperationResult : OperationResult<OperationResult>
{
    public static OperationResult Created() => new OperationResult { ResultStatus = ResultStatus.Created };
}