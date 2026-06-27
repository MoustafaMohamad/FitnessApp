using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Common.Services;
using FitnessCalculationEngine.Data.Contexts;
using FitnessCalculationEngine.Features.Common.Data;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCalculationEngine.Common.BaseHandler
{
    public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        protected readonly IMediator _mediator;
        protected readonly Context _context;
        protected readonly IdGen.IIdGenerator<long> _snowflake;
        protected readonly CurrentUserService _currentUserService;

        public BaseHandler(BaseParameters baseParameters)
        {
            _mediator = baseParameters._mediator;
            _context = baseParameters._context;
            _snowflake = baseParameters._snowflake;
            _currentUserService = baseParameters._currentUserService;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    }
}

