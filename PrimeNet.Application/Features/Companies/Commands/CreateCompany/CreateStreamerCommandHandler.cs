using AutoMapper;
using PrimeNet.Application.Contracts.Infrastructure;
using PrimeNet.Application.Contracts.Persistence;
using PrimeNet.Application.Model;
using PrimeNet.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace PrimeNet.Application.Features.Streamers.Commands.CreateStreamer;

public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
{
    private readonly IStreamerRepository _streamerRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CreateStreamerCommandHandler> _logger;

    public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService,
        ILogger<CreateStreamerCommandHandler> logger)
    {
        _streamerRepository = streamerRepository;
        _mapper = mapper;
        _emailService = emailService;
        _logger = logger;
    }

    public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
    {
        var streamerEntity = _mapper.Map<Streamer>(request);
        var newStreamer = await _streamerRepository.AddAsync(streamerEntity);
        _logger.LogInformation($"Streamer {newStreamer.Id} Created Successfully");

        await SendEmail(newStreamer);
        return newStreamer.Id;
    }

    private async Task SendEmail(Streamer streamer)
    {
        var email = new Email()
        {
            To = "alafourcadedespaigne@gmail.com",
            Body = "Streamer Company created successfully",
            Subject = "Alert Message"
        };
        try
        {
            await _emailService.SendEmail(email);
        }
        catch (Exception e)
        {
            _logger.LogError($"Errors sending email to {streamer.Id}");
            Console.WriteLine(e);
            throw;
        }
    }
}