namespace Academy.API.Models.Responses.Base;

public interface IOperationResult
{
    ResultStatus ResultStatus { get; set; }
    IList<ValidationError> ValidationErrors { get; set; }
    IList<ApplicationError> ApplicationErrors { get; set; }

    bool Succeeded();
}