using Academy.API.Models.Responses.Base;

namespace Academy.API.Models.Responses.Generic;

public class OperationResult<T> : IOperationResult
{
    public T Value { get; set; }
    public ResultStatus ResultStatus { get; set; }
    public IList<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();
    public IList<ApplicationError> ApplicationErrors { get; set; } = new List<ApplicationError>();
    
    public bool Succeeded()
    {
        return ResultStatus is
            ResultStatus.Ok or
            ResultStatus.Created;
    }

    public static OperationResult<T> Success(T type)
    {
        return new OperationResult<T>
        {
            ResultStatus = ResultStatus.Ok,
            Value = type
        };
    }

    public static OperationResult<T> NotFound()
    {
        return new OperationResult<T>
        {
            ResultStatus = ResultStatus.NotFound
        };
    }
}