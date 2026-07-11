using MediatR;

namespace ProgressTrackingService.Common.Interface
{
    public interface ICommand<TResponse> : IRequest<TResponse> 
    {
    }
}
