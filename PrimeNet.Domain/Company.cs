using System;
using PrimeNet.Domain.Common;

namespace PrimeNet.Domain
{
    public class Company:BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        
        public ICollection<Movie>? Movies { get; set; }


    }
}

