using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

[MessagePackObject(keyAsPropertyName: true)]
public record EstablishmentLocationDto
{
    public int LocationType { get; init; }
    public uint TerritoryId { get; init; }

    // Housing
    public ulong? ServerId { get; init; }
    public uint? WardId { get; init; }
    public uint? PlotId { get; init; }
    public uint? DivisionId { get; init; }
    public bool? IsApartment { get; init; }
    public uint? RoomId { get; init; }

    // Zone
    public float? X { get; init; }
    public float? Y { get; init; }
    public float? Z { get; init; }
    public float? Radius { get; init; }
}
