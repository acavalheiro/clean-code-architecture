using MediatR;

namespace CleanCodeArchitecture.Domain.Core.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}