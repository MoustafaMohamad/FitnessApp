using FitnessCalculationEngine.Common.Exceptions;
using FitnessCalculationEngine.Common.Interface;
using FitnessCalculationEngine.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace FitnessCalculationEngine.Common.Behaviors
{
    public class TransactionMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
    {

        private Context _context;
        public TransactionMiddleware(Context context)
        {
            _context = context;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if (_context.Database.CurrentTransaction != null)
                return await next();

            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var response = await next();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync(cancellationToken);

                return response;
            }
            catch (BusinessException)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
