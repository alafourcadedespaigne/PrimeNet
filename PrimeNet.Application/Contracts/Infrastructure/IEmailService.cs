using PrimeNet.Application.Model;

namespace PrimeNet.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}