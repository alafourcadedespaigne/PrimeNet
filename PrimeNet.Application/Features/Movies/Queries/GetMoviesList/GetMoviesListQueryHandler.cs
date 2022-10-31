using AutoMapper;
using PrimeNet.Application.Contracts.Persistence;
using MediatR;

namespace PrimeNet.Application.Features.Videos.Queries.GetVideosList;

public class GetVideosListQueryhandler: IRequestHandler<GetVideosListQuery, List<VideosVm>>
{
    private readonly IVideoRepository _videoRepository;
    private readonly IMapper _mapper;

    public GetVideosListQueryhandler(IVideoRepository videoRepository, IMapper mapper)
    {
        _videoRepository = videoRepository;
        _mapper = mapper;
    }

    public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
    {
        var videoList = _videoRepository.GetVideoByUserName(request.Username);
        return _mapper.Map<List<VideosVm>>(videoList);
    }
}