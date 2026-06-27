using FitnessCalculationEngine.Data.Contexts;

namespace FitnessCalculationEngine.Common.Middlewares
{
    public class TransactionMiddleware : IMiddleware
    {
        private readonly Context _context;

        public TransactionMiddleware(Context context)
        {
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await next(context);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
