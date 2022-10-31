using MediatR;
using Microsoft.Extensions.Logging;

namespace PrimeNet.Application.Behaviours;

public class UnHandleexceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnHandleexceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception e)
        {
            var requesName = typeof(TRequest).Name;
            _logger.LogError(e, "Application Request: Occur an exception for request {Name} {@Request}", requesName,
                request);
            throw;
        }
    }
}