using CleanCodeArchitecture.Domain.Core.Response;
using MediatR;

namespace CleanCodeArchitecture.Domain.Core.Commands;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<Result<TResponse>>
{
}