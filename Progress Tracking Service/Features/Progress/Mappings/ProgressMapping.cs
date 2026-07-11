using Mapster;
using Progress_Tracking_Service.Entities;
using ProgressTrackingService.Features.Progress.Dtos;

namespace ProgressTrackingService.Features.Progress.Mappings;

public sealed class ProgressMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddWeightRequestDto, WeightHistory>()
            .Ignore(destination => destination.Id)
            .Ignore(destination => destination.UserId);
        config.NewConfig<WeightHistory, WeightHistoryDto>();
        config.NewConfig<UserStatistics, UserStatisticsDto>()
            .Map(destination => destination.UserId, source => source.Id);
        config.NewConfig<Streak, StreakDto>();
    }
}
