using PrimeNet.Domain;

namespace PrimeNet.Application.Contracts.Persistence;

public interface IVideoRepository: IAsyncRepository<Movie>
{
    Task<Movie> GetMovieByName(string name);
    Task<IEnumerable<Movie>> GetMovieByUserName(string username);
}