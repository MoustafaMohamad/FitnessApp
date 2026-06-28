using FluentValidation;
using MediatR;
using Workout_Exercise_Catalog.Common.Helpers;
using System.Text;
using Workout_Exercise_Catalog.Common.Exceptions;

namespace Workout_Exercise_Catalog.Common.Behaviors
{

    public class ValidationPipelineBehavior<TRequest, TResponse>
 : IPipelineBehavior<TRequest, TResponse>
 where TRequest : IRequest<TResponse>

    {
        private readonly CancellationTokenAccessor _cancellationTokenAccessor;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators, CancellationTokenAccessor cancellationTokenAccessor)
        {
            _validators = validators;
            _cancellationTokenAccessor = cancellationTokenAccessor;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(validator => validator.ValidateAsync(context, _cancellationTokenAccessor.Token)));
                if (validationResults.Any(x => !x.IsValid))
                {
                    var errors = new StringBuilder();
                    foreach (var validationResult in validationResults)
                    {
                        if (!validationResult.IsValid)
                        {
                            errors.AppendLine(string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage)));
                        }
                    }
                    throw new RequstValidationException(errors.ToString());
                }
                return await next();
            }


            return await next();
        }

    }
}
