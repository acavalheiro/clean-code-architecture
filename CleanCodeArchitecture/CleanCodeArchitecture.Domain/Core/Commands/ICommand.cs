using CleanCodeArchitecture.Domain.Core.Response;
using MediatR;

namespace CleanCodeArchitecture.Domain.Core.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse> 
// where TResponse : BaseResponse
{
}