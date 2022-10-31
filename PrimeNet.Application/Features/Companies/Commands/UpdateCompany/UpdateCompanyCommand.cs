using MediatR;

namespace PrimeNet.Application.Features.Companies.Commands.UpdateCompany;

public class UpdateCompanyCommand: IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Url { get; set; } = String.Empty;
    
    
}