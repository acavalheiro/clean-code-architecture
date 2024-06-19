﻿using CleanCodeArchitecture.Domain.Core.Commands;
using FluentValidation;
using MediatR;

namespace CleanCodeArchitecture.Application.Core.PipelineBehavior;

public sealed class ValidationBehavior<TRequest, TResponse> : Domain.Core.PipelineBehavior.IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (!_validators.Any())
        {
            return await next();
        }
        var context = new ValidationContext<TRequest>(request);


        var errorsDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors);
            
        if (errorsDictionary.Any())
        {
            throw new ValidationException(errorsDictionary);
        }
        return await next();
    }
}