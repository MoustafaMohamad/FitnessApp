using FitnessCalculationEngine.Features.UserFitnessStatsFeature.command;
using FitnessCalculationEngine.Features.UserFitnessStatsFeature.ViewModels;
using Mapster;

namespace FitnessCalculationEngine.Features.UserFitnessStatsFeature.Profiles
{
    public class UserFitnessStatsProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SubmitUserFitnessStatsViewModel, SubmitUserFitnessStatsCommand>();
        }
    }
}
