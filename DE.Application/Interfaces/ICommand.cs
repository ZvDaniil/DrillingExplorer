using MediatR;

namespace DE.Application.Interfaces;

public interface ICommand : IRequest
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
}