using MediatR;

namespace DE.Application.Interfaces;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
{
}