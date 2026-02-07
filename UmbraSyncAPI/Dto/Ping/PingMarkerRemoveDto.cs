using MessagePack;

namespace UmbraSync.API.Dto.Ping;

[MessagePackObject(keyAsPropertyName: true)]
public record PingMarkerRemoveDto
{
    public Guid PingId { get; set; }
}
