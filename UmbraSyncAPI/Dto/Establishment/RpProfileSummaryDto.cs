using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

[MessagePackObject(keyAsPropertyName: true)]
public record RpProfileSummaryDto
{
    public int Id { get; init; }
    public string CharacterName { get; init; } = string.Empty;
    public uint WorldId { get; init; }
    public string? RpFirstName { get; init; }
    public string? RpLastName { get; init; }
}
