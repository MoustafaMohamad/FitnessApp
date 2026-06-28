


using MediatR;
using Workout_Exercise_Catalog.Common;
using Workout_Exercise_Catalog.Common.Helpers;
using Workout_Exercise_Catalog.Data.Contexts;

namespace Workout_Exercise_Catalog.Features.Common
{
    public class RequestParameters
    {
        public IMediator Mediator { get; set; }
        public CancellationTokenAccessor CancellationTokenAccessor { get; set; }
        public UserState UserState { get; set; }
        public Context _context { get; set; }

        public RequestParameters(IMediator mediator, CancellationTokenAccessor cancellationTokenAccessor, UserState userState, Context context)
        {
            Mediator = mediator;
            CancellationTokenAccessor = cancellationTokenAccessor;
            UserState = userState;
            _context = context;
        }
    }
}
