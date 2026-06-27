using FitnessCalculationEngine.Common.Services;
using FitnessCalculationEngine.Data.Contexts;
using FluentValidation;
using MediatR;

namespace FitnessCalculationEngine.Common.BaseHandler
{
    public class BaseParameters
    {
        public readonly IMediator _mediator;
        public readonly IdGen.IIdGenerator<long> _snowflake;
        public readonly Context _context;
        public readonly CurrentUserService _currentUserService;
        public BaseParameters(IMediator mediator, IdGen.IIdGenerator<long> idGenerator,Context context, CurrentUserService currentUserService)
        {
            _mediator = mediator;
            _snowflake = idGenerator;
            _context = context;
            _currentUserService = currentUserService;
        }
    }
}
