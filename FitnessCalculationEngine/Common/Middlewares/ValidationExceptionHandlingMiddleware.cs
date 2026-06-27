using FitnessCalculationEngine.Common.Exceptions;
using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.Common.Data;

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
