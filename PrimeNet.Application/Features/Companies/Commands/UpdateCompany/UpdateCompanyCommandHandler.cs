using System.Globalization;
using AutoMapper;
using PrimeNet.Application.Contracts.Infrastructure;
using PrimeNet.Application.Contracts.Persistence;
using PrimeNet.Application.Exceptions;
using PrimeNet.Application.Features.Companies.Commands.CreateCompany;
using PrimeNet.Application.Model;
using PrimeNet.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace PrimeNet.Application.Features.Companies.Commands.UpdateCompany;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<UpdateCompanyCommand> _logger;

    public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper,
        IEmailService emailService,
        ILogger<UpdateCompanyCommand> logger)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _emailService = emailService;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var companyToUpdate = await _companyRepository.GetByIdAsync(request.Id);
        if (companyToUpdate == null)
        {
            _logger.LogError($"Company Id{request.Id} not found");
            throw new NotFoundException(nameof(Company), request.Id);
        }

        _mapper.Map(request, companyToUpdate, typeof(UpdateCompanyCommand), 
            typeof(Company));
        await _companyRepository.UpdateAsync(companyToUpdate);
        _logger.LogInformation($"The operation was successfully updating the company {request.Id}");
        return Unit.Value;
    }

    private async Task SendEmail(Company company)
    {
        var email = new Email()
        {
            To = "alafourcadedespaigne@gmail.com",
            Body = "Company Company created successfully",
            Subject = "Alert Message"
        };
        try
        {
            await _emailService.SendEmail(email);
        }
        catch (Exception e)
        {
            _logger.LogError($"Errors sending email to {company.Id}");
            Console.WriteLine(e);
            throw;
        }
    }
}