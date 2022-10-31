using CleanArchitectureLab.Application.Model;

namespace CleanArchitectureLab.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}