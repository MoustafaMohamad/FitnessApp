using MediatR;
using Microsoft.EntityFrameworkCore;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Features.Common;
using Workout_Exercise_Catalog.Features.Common.Views;

namespace Workout_Exercise_Catalog.Features.Common.Queries.Categories
{
    public record IsCategoryExistQuery(string? CategoryName) : IRequest<RequestResult<bool>>;

    public class IsCategoryExistQueryHandler : BaseRequestHandler<IsCategoryExistQuery, RequestResult<bool>>
    {
        private readonly Context _context;

        public IsCategoryExistQueryHandler(Context context, RequestParameters requestParameters) : base(requestParameters)
        {
            _context = context;
        }

        public override async Task<RequestResult<bool>> Handle(IsCategoryExistQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.CategoryName))
            {
                return RequestResult<bool>.Success(false);
            }

            var categoryName = request.CategoryName.Trim().ToLower();
            var exists = await _context.Categorys
                .AsNoTracking()
                .AnyAsync(x => x.Name.ToLower() == categoryName, cancellationToken);

            return RequestResult<bool>.Success(exists);
        }
    }
}
