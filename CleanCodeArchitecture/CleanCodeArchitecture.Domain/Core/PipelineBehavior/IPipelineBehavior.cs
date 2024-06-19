using MediatR;

namespace CleanCodeArchitecture.Domain.Core.PipelineBehavior;

public interface IPipelineBehavior<in TRequest, TResponse> where TRequest : notnull
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
}