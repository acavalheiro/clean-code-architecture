using MediatR;

namespace CleanCodeArchitecture.Domain.Core.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}