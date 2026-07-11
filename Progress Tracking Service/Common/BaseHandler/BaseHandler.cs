using DotNetCore.CAP;
using ProgressTrackingService.Common.Services;
using ProgressTrackingService.Data.Contexts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProgressTrackingService.Common.BaseHandler
{
    public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        protected readonly IMediator _mediator;
        protected readonly Context _context;
        protected readonly IdGen.IIdGenerator<long> _snowflake;
        protected readonly ICapPublisher _capPublisher;
        protected readonly CurrentUserService _currentUserService;
        protected readonly EnumLookupCache _enumLookupCache;


        public BaseHandler(BaseParameters baseParameters)
        {
            _mediator = baseParameters._mediator;
            _context = baseParameters._context;
            _snowflake = baseParameters._snowflake;
            _currentUserService = baseParameters._currentUserService;
            _enumLookupCache = baseParameters._enumLookupCache;
            _capPublisher = baseParameters._capPublisher;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    }
}

