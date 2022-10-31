using PrimeNet.Domain.Common;

namespace PrimeNet.Domain
{
    public class Movie : BaseDomainModel
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
        }
        public string? Name { get; set; }

        public int CompanyId { get; set; }

        public virtual Company? Company { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        
        public virtual Productor? Productor { get; set; }
    }
}