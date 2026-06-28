using MediatR;

namespace Workout_Exercise_Catalog.Features.Common
{
    public class NotificationParameters
    {
        public IMediator Mediator { get; set; }

        public NotificationParameters(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
