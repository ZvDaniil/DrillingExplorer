using MediatR;
using Serilog;

namespace DE.Application.Common.Behaviors;

public class LoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseRequest
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        Log.Information("Handling {Name} {@Request}", typeof(TRequest).Name, request);

        var response = await next();
        Log.Information("Handled  {Name} {@Response}", typeof(TResponse).Name, response);

        return response;
    }
}