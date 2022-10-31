using CleanArchitectureLab.Domain.Common;

namespace CleanArchitectureLab.Domain;

public class VideoActor : BaseDomainModel
{
    public int VideoId { get; set; }
    public int ActorId { get; set; }
}