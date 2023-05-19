using MediatR;

namespace DE.Application.Interfaces;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}