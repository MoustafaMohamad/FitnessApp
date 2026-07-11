using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgressTrackingService.Common.BaseHandler;
using ProgressTrackingService.Common.ResultPattern;
using ProgressTrackingService.Features.Progress.Dtos;

namespace ProgressTrackingService.Features.Progress.Queries;

public record GetWeightHistoryQuery(long UserId) : IRequest<RequestResult<IReadOnlyCollection<WeightHistoryDto>>>;

public class GetWeightHistoryQueryHandler : BaseHandler<GetWeightHistoryQuery, RequestResult<IReadOnlyCollection<WeightHistoryDto>>>
{
    private readonly IMapper _mapper;

    public GetWeightHistoryQueryHandler(BaseParameters baseParameters, IMapper mapper) : base(baseParameters) => _mapper = mapper;

    public override async Task<RequestResult<IReadOnlyCollection<WeightHistoryDto>>> Handle(GetWeightHistoryQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.WeightHistory.Where(item => item.UserId == request.UserId)
            .OrderByDescending(item => item.Date).ToListAsync(cancellationToken);

        return RequestResult<IReadOnlyCollection<WeightHistoryDto>>.Success(_mapper.Map<List<WeightHistoryDto>>(items));
    }
}
