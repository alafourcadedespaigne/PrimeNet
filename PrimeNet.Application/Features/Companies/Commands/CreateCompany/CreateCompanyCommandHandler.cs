using AutoMapper;
using PrimeNet.Application.Contracts.Infrastructure;
using PrimeNet.Application.Contracts.Persistence;
using PrimeNet.Application.Model;
using PrimeNet.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace PrimeNet.Application.Features.Companies.Commands.CreateCompany;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CreateCompanyCommandHandler> _logger;

    public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper, IEmailService emailService,
        ILogger<CreateCompanyCommandHandler> logger)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _emailService = emailService;
        _logger = logger;
    }

    public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var companyEntity = _mapper.Map<Company>(request);
        var newCompany = await _companyRepository.AddAsync(companyEntity);
        _logger.LogInformation($"Company {newCompany.Id} Created Successfully");

        await SendEmail(newCompany);
        return newCompany.Id;
    }

    private async Task SendEmail(Company company)
    {
        var email = new Email()
        {
            To = "alafourcadedespaigne@gmail.com",
            Body = "Company  created successfully",
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