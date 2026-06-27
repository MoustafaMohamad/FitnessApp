using FitnessCalculationEngine.Common.BaseHandler;
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
                ActivityLevel = request.ActivityLevel,
                Age = request.Age,
                Gender = request.Gender,
                Goal = request.Goal,
                Height = request.Height,
                Weight = request.Weight,
                UserId = _currentUserService.UserId


            };
            await _context.UserFitnessStats.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
