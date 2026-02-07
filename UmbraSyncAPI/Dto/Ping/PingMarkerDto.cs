using MessagePack;
using UmbraSync.API.Data.Enum;

namespace UmbraSync.API.Dto.Ping;

[MessagePackObject(keyAsPropertyName: true)]
public record PingMarkerDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public PingMarkerType Type { get; set; }
    public float PositionX { get; set; }
    public float PositionY { get; set; }
    public float PositionZ { get; set; }
    public uint TerritoryId { get; set; }
    public uint MapId { get; set; }
    public long Timestamp { get; set; }
}
