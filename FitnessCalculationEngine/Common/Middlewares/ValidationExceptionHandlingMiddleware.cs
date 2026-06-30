using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Common.Exceptions;
using FitnessCalculationEngine.Common.ResultPattern;

namespace FitnessCalculationEngine.Common.Middlewares
{
    public class ValidationExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (RequestValidationException exception)
            {
                string message = exception.Message;
                var result = EndpointResponse<bool>.Failure(ErrorCode.InvalidInput, message);

                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }

}
