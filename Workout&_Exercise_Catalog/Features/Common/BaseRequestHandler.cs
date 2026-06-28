using MediatR;
using Workout_Exercise_Catalog.Common;
using Workout_Exercise_Catalog.Data.Contexts;

namespace Workout_Exercise_Catalog.Features.Common
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IMediator _mediator;
        protected readonly CancellationToken _cancellationToken;
        protected readonly UserState _userState;
        protected readonly Context _context;

        public BaseRequestHandler(RequestParameters requestParameters)
        {
            _mediator = requestParameters.Mediator;
            _cancellationToken = requestParameters.CancellationTokenAccessor.Token;
            _userState = requestParameters.UserState;
            _context = requestParameters._context;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
