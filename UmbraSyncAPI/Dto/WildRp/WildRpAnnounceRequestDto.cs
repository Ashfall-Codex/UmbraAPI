using MessagePack;

namespace UmbraSync.API.Dto.WildRp;

[MessagePackObject(keyAsPropertyName: true)]
public record WildRpAnnounceRequestDto
{
    public uint WorldId { get; init; }
    public uint TerritoryId { get; init; }
    public uint? WardId { get; init; }
    public string? CharacterName { get; init; }
    public string? Message { get; init; }
    public int? RpProfileId { get; init; }
}
