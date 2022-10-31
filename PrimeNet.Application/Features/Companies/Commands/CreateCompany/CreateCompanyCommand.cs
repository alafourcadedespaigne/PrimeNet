using MediatR;

namespace PrimeNet.Application.Features.Companies.Commands.CreateCompany;

public class CreateCompanyCommand:IRequest<int>
{
    public string Name { get; set; } = string.Empty; 
    public string Url { get; set; }= string.Empty; 
}