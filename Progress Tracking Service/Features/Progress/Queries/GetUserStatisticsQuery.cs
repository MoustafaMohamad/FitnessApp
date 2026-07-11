using MapsterMapper;
using MediatR;
using ProgressTrackingService.Common.BaseHandler;
using ProgressTrackingService.Common.Enums;
using ProgressTrackingService.Common.ResultPattern;
using ProgressTrackingService.Features.Progress.Dtos;

namespace ProgressTrackingService.Features.Progress.Queries;

public record GetUserStatisticsQuery(long UserId) : IRequest<RequestResult<UserStatisticsDto>>;

public class GetUserStatisticsQueryHandler : BaseHandler<GetUserStatisticsQuery, RequestResult<UserStatisticsDto>>
{
    private readonly IMapper _mapper;

    public GetUserStatisticsQueryHandler(BaseParameters baseParameters, IMapper mapper) : base(baseParameters) => _mapper = mapper;

    public override async Task<RequestResult<UserStatisticsDto>> Handle(GetUserStatisticsQuery request, CancellationToken cancellationToken)
    {
        var statistics = await _context.UserStatisticss.FindAsync([request.UserId], cancellationToken);

        return statistics is null
            ? RequestResult<UserStatisticsDto>.Failure(ErrorCode.BadRequest, "Statistics were not found.")
            : RequestResult<UserStatisticsDto>.Success(_mapper.Map<UserStatisticsDto>(statistics));
    }
}
