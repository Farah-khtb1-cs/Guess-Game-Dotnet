using Microsoft.AspNetCore.Mvc;

namespace GameApp.Filters;

public class GameValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        // Get A and B from route parameters
        var a = context.GetArgument<int>(0);
        var b = context.GetArgument<int>(1);

        var validationErrors = new List<string>();

        // Validate A and B (same logic as Razor page)
        if (a < 1 || a > 10)
        {
            validationErrors.Add("A must be between 1 and 10");
        }

        if (b < 1 || b > 10)
        {
            validationErrors.Add("B must be between 1 and 10");
        }

        if (a >= b)
        {
            validationErrors.Add("A must be less than B");
        }

        if (b % 2 != 0)
        {
            validationErrors.Add("B must be a multiple of 2");
        }

        // If there are validation errors, return Problem
        if (validationErrors.Any())
        {
            return Results.ValidationProblem(validationErrors.ToDictionary(e => e, e => new[] { e }));
        }

        // If validation passes, continue to the endpoint
        return await next(context);
    }
} 