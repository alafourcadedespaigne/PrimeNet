using PrimeNet.Domain.Common;
using PrimeNet.Domain.Common;

namespace PrimeNet.Domain;

public class MovieActor : BaseDomainModel
{
    public int MovieId { get; set; }
    public int ActorId { get; set; }
}