using PrimeNet.Domain.Common;

namespace PrimeNet.Domain;

public class Actor:BaseDomainModel
{
    public Actor()
    {
        Movies = new HashSet<Movie>();
    }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}