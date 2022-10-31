using AutoMapper;
using PrimeNet.Application.Features.Companies.Commands;
using PrimeNet.Application.Features.Companies.Commands.CreateCompany;
using PrimeNet.Application.Features.Movies.Queries.GetMoviesList;
using PrimeNet.Domain;

namespace PrimeNet.Application.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Movie, MoviesVm>();
        CreateMap<CreateCompanyCommand, Company>();
    }
    
    
}