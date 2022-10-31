using PrimeNet.Domain.Common;

namespace PrimeNet.Domain;

public class Productor:BaseDomainModel
{
    public string Name { get; set; }
    public string LastName { get; set; }

    public int MovieId { get; set; }

    public virtual Movie? Movie { get; set; }
}