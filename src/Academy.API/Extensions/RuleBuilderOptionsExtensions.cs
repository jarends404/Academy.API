using FluentValidation;

namespace Academy.API.Extensions;

public static class RuleBuilderOptionsExtensions
{
    public static IRuleBuilderOptions<T, string> MustBeValidDate<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(date => DateOnly.TryParse(date, out _));
    }
    
    public static IRuleBuilderOptions<T, string> MustBeInTheFuture<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(date =>
        {
            if (DateOnly.TryParse(date, out var parsedDate))
            {
                return parsedDate > DateOnly.FromDateTime(DateTime.Now);
            }
            return false;
        });
    }
}