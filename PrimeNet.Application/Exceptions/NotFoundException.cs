namespace PrimeNet.Application.Exceptions;

public class NotFoundException:ApplicationException
{
    public NotFoundException(string name, object key):base($"Entity\"{name}\"({key}) No was founded")
    {
        
    }
}