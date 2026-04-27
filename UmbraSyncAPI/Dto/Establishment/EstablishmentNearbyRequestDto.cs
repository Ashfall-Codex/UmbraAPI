using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

[MessagePackObject(keyAsPropertyName: true)]
public record EstablishmentNearbyRequestDto
{
    public uint TerritoryId { get; init; }
    public ulong? ServerId { get; init; }
    public uint? WardId { get; init; }
    public uint? DivisionId { get; init; }
    public float X { get; init; }
    public float Y { get; init; }
    public float Z { get; init; }
    public float Radius { get; init; } = 100f;
}
