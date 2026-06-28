using Workout_Exercise_Catalog.Data.Contexts;

namespace Workout_Exercise_Catalog.Common.Middlewares
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
            string method = context.Request.Method.ToUpper();

            if (method == "POST" || method == "PUT" || method == "DELETE")
            {
                var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    await next(context);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            else
            {
                await next(context);
            }
        }
    }
}
