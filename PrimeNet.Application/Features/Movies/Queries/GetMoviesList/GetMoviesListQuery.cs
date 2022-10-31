using PrimeNet.Domain;
using MediatR;

namespace PrimeNet.Application.Features.Movies.Queries.GetMoviesList;

public class GetMoviesListQuery:IRequest<List<MoviesVm>>
{
    public string Username { get; set; } = String.Empty;

    public GetMoviesListQuery(string username)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
    }
}