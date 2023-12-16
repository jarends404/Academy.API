using Academy.API.Models.Responses.Base;
using FluentValidation.Results;

namespace Academy.API.Extensions;

public static class ValidationResultExtensions
{
    public static List<ValidationError> AsValidationErrors(this ValidationResult validationResult)
    {
        return validationResult.Errors
            .Select(error => new ValidationError
            {
                Identifier = error.PropertyName,
                Message = error.ErrorMessage
            }).ToList();
    }
}