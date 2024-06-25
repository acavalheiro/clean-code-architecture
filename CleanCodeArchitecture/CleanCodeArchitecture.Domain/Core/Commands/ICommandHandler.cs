using CleanCodeArchitecture.Domain.Core.Response;
using MediatR;

namespace CleanCodeArchitecture.Domain.Core.Commands;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
// where TResponse : BaseResponse
{
}