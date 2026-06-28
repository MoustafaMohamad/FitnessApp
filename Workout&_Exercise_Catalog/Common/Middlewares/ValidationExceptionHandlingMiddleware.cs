using Workout_Exercise_Catalog.Common.Exceptions;
using Workout_Exercise_Catalog.Features.Common.Data;
using Workout_Exercise_Catalog.Features.Common.Views;

namespace Workout_Exercise_Catalog.Common.Middlewares
{
    public class ValidationExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (RequstValidationException exception)
            {
                string message = exception.Message;
                var result = EndpointResponse<bool>.Failure(ErrorCode.InvalidInput, message);

                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }

}
