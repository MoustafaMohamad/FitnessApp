using DotNetCore.CAP;
using ProgressTrackingService.Common.Services;
using ProgressTrackingService.Data.Contexts;
using FluentValidation;
using MediatR;

namespace ProgressTrackingService.Common.BaseHandler
{
    public class BaseParameters
    {
        public readonly IMediator _mediator;
        public readonly IdGen.IIdGenerator<long> _snowflake;
        public readonly ICapPublisher _capPublisher;
        public readonly Context _context;
        public readonly CurrentUserService _currentUserService;
        public readonly EnumLookupCache _enumLookupCache;
        public BaseParameters(IMediator mediator,
            IdGen.IIdGenerator<long> idGenerator,
            Context context, CurrentUserService currentUserService,
            EnumLookupCache enumLookupCache,
            ICapPublisher capPublisher)
        {
            _mediator = mediator;
            _snowflake = idGenerator;
            _context = context;
            _enumLookupCache = enumLookupCache;
            _currentUserService = currentUserService;
            _capPublisher = capPublisher;
        }
    }
}
