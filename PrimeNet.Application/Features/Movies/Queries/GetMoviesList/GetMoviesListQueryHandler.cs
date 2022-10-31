using AutoMapper;
using PrimeNet.Application.Contracts.Persistence;
using MediatR;

namespace PrimeNet.Application.Features.Movies.Queries.GetMoviesList;

public class GetMoviesListQueryhandler: IRequestHandler<GetMoviesListQuery, List<MoviesVm>>
{
    private readonly IMovieRepository _videoRepository;
    private readonly IMapper _mapper;

    public GetMoviesListQueryhandler(IMovieRepository videoRepository, IMapper mapper)
    {
        _videoRepository = videoRepository;
        _mapper = mapper;
    }

    public async Task<List<MoviesVm>> Handle(GetMoviesListQuery request, CancellationToken cancellationToken)
    {
        var videoList = _videoRepository.GetMovieByUserName(request.Username);
        return _mapper.Map<List<MoviesVm>>(videoList);
    }
}