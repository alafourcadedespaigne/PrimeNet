using AutoMapper;
using PrimeNet.Application.Contracts.Infrastructure;
using PrimeNet.Application.Contracts.Persistence;
using PrimeNet.Application.Exceptions;
using PrimeNet.Application.Features.Streamers.Commands.CreateStreamer;
using PrimeNet.Application.Model;
using PrimeNet.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace PrimeNet.Application.Features.Streamers.Commands.DeleteStreamer;

public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
{
    private readonly IStreamerRepository _streamerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteStreamerCommandHandler> _logger;

    public DeleteStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper,
        ILogger<DeleteStreamerCommandHandler> logger)
    {
        _streamerRepository = streamerRepository;
        _mapper = mapper;
        _logger = logger;
    }


    public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
    {
        var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);
        if (streamerToDelete == null)
        {
            _logger.LogError($"{request.Id} company don't exist in the system");
            throw new NotFoundException(nameof(Company), request.Id);
        }

        await _streamerRepository.DeleteAsync(streamerToDelete);
        _logger.LogInformation($"The Company with Id: {request.Id} was deleted successfully");
        return Unit.Value;
    }
}