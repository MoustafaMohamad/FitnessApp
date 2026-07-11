using FluentValidation;
using MapsterMapper;
using Progress_Tracking_Service.Entities;
using ProgressTrackingService.Common.BaseHandler;
using ProgressTrackingService.Common.Enums;
using ProgressTrackingService.Common.Interface;
using ProgressTrackingService.Common.ResultPattern;
using ProgressTrackingService.Features.Common.AppLogs.Commands;
using ProgressTrackingService.Features.Progress.Dtos;

namespace ProgressTrackingService.Features.Progress.Commands;

public  record AddWeightCommand(AddWeightRequestDto Data) : ICommand<RequestResult<WeightHistoryDto>>;

public  class AddWeightCommandValidator : AbstractValidator<AddWeightCommand>
{
    public AddWeightCommandValidator()
    {
        RuleFor(command => command.Data.Weight).GreaterThan(0);
        RuleFor(command => command.Data.Date).NotEmpty();
        RuleFor(command => command.Data.Notes).MaximumLength(500);
    }
}

public  class AddWeightCommandHandler : BaseHandler<AddWeightCommand, RequestResult<WeightHistoryDto>>
{
    private readonly IMapper _mapper;
    public AddWeightCommandHandler(BaseParameters baseParameters, IMapper mapper) : base(baseParameters) => _mapper = mapper;

    public override async Task<RequestResult<WeightHistoryDto>> Handle(AddWeightCommand request, CancellationToken cancellationToken)
    {
        var history = _mapper.Map<WeightHistory>(request.Data);
        history.Id = _snowflake.CreateId();
        history.UserId = _currentUserService.UserId;
        await _context.WeightHistory.AddAsync(history, cancellationToken);

        var statistics = await _context.UserStatisticss.FindAsync([history.UserId], cancellationToken);
        if (statistics is null)
        {
            statistics = new UserStatistics { Id = history.UserId, StartWeight = history.Weight };
            _context.UserStatisticss.Add(statistics);
        }
        statistics.CurrentWeight = history.Weight;
        statistics.TotalWeightLost = statistics.StartWeight - history.Weight;

        await _mediator.Send(new AddLogCommand(LogLevels.Information, $"Weight history {history.Id} was added for user {history.UserId}."), cancellationToken);
        await _capPublisher.PublishAsync("weight_updated", new { history.UserId, history.Weight, history.Date }, cancellationToken: cancellationToken);
        return RequestResult<WeightHistoryDto>.Success(_mapper.Map<WeightHistoryDto>(history), "Weight entry added successfully.");
    }
}
