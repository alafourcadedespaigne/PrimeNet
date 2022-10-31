using AutoMapper;
using PrimeNet.Application.Contracts.Infrastructure;
using PrimeNet.Application.Contracts.Persistence;
using PrimeNet.Application.Exceptions;
using PrimeNet.Application.Features.Companies.Commands.CreateCompany;
using PrimeNet.Application.Model;
using PrimeNet.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace PrimeNet.Application.Features.Companies.Commands.DeleteCompany;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteCompanyCommandHandler> _logger;

    public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper,
        ILogger<DeleteCompanyCommandHandler> logger)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _logger = logger;
    }


    public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var companyToDelete = await _companyRepository.GetByIdAsync(request.Id);
        if (companyToDelete == null)
        {
            _logger.LogError($"{request.Id} Company don't exist in the system");
            throw new NotFoundException(nameof(Company), request.Id);
        }

        await _companyRepository.DeleteAsync(companyToDelete);
        _logger.LogInformation($"The Company with Id: {request.Id} was deleted successfully");
        return Unit.Value;
    }
}