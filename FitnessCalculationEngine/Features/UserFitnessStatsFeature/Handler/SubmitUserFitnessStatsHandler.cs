
using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Common.Services;
using FitnessCalculationEngine.Entities;
using FitnessCalculationEngine.Features.UserFitnessStatsFeature.command;

namespace FitnessCalculationEngine.Features.UserFitnessStatsFeature.Handler
{
    public class SubmitUserFitnessStatsHandler : BaseHandler<SubmitUserFitnessStatsCommand, bool>
    {
        public SubmitUserFitnessStatsHandler(BaseParameters baseParameters) : base(baseParameters)
        {
        }

        public override async Task<bool> Handle(SubmitUserFitnessStatsCommand request, CancellationToken cancellationToken)
        {

            var entity = new UserFitnessStats
            {
                Id = _snowflake.CreateId(),
                Age = request.Age,
                Height = request.Height,
                Weight = request.Weight,
                GenderId = await _enumLookupCache.GetLookupId(request.Gender),
                ActivityLevelId = await _enumLookupCache.GetLookupId(request.ActivityLevel),
                GoalId = await _enumLookupCache.GetLookupId(request.Goal),
                UserId = _currentUserService.UserId
                

            };
            
            await _context.UserFitnessStats.AddAsync(entity, cancellationToken);

            return true;
        }
    }
}
