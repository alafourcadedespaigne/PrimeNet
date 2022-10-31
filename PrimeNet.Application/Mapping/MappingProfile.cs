using AutoMapper;
using CleanArchitectureLab.Application.Features.Streamers.Commands;
using CleanArchitectureLab.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitectureLab.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitectureLab.Domain;

namespace CleanArchitectureLab.Application.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Video, VideosVm>();
        CreateMap<CreateStreamerCommand, Streamer>();
    }
    
    
}