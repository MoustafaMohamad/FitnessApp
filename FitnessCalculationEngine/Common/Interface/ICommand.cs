using MediatR;

namespace FitnessCalculationEngine.Common.Interface
{
    public interface ICommand<TResponse> : IRequest<TResponse> 
    {
    }
}
