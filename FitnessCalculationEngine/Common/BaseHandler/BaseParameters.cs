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
        public readonly EnumLookupCache _enumLookupCache;
        public BaseParameters(IMediator mediator,
            IdGen.IIdGenerator<long> idGenerator,
            Context context, CurrentUserService currentUserService,
            EnumLookupCache enumLookupCache)
        {
            _mediator = mediator;
            _snowflake = idGenerator;
            _context = context;
            _enumLookupCache = enumLookupCache;
            _currentUserService = currentUserService;
        }
    }
}
