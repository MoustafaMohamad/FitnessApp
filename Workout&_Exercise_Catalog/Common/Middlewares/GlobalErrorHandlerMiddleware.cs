using MediatR;
using Workout_Exercise_Catalog.Features.Common.AppLogs.Commands;
using Workout_Exercise_Catalog.Features.Common.Data;
using Workout_Exercise_Catalog.Features.Common.Views;

namespace Workout_Exercise_Catalog.Common.Middlewares
{
    public class GlobalErrorHandlerMiddleware : IMiddleware
    {

        private readonly IMediator _mediator;

        public GlobalErrorHandlerMiddleware(IMediator mediator)
        {

            _mediator = mediator;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (OperationCanceledException)
            {
                var result = EndpointResponse<bool>.Failure(ErrorCode.ClientClosedRequest);
                await context.Response.WriteAsJsonAsync(result);
            }
            catch (Exception ex)
            {

                string message = $"Error Occured: {ex.Message}.";
                ErrorCode errorCode = ErrorCode.UnKnown;

                var loggingMessage = $"Error Occured: {ex.Message}";
                await _mediator.Send(new AddLogCommand(LogLevels.Error, loggingMessage));

                var result = EndpointResponse<bool>.Failure(errorCode);

                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }

}
