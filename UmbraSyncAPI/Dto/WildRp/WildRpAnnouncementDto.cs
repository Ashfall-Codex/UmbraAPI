using MessagePack;

namespace UmbraSync.API.Dto.WildRp;

[MessagePackObject(keyAsPropertyName: true)]
public record WildRpAnnouncementDto
{
    public Guid Id { get; init; }
    public string UserUID { get; init; } = string.Empty;
    public string? UserAlias { get; init; }
    public uint WorldId { get; init; }
    public uint TerritoryId { get; init; }
    public string? Message { get; init; }
    public string? RpFirstName { get; init; }
    public string? RpLastName { get; init; }
    public string? RpProfilePictureBase64 { get; init; }
    public DateTime CreatedAtUtc { get; init; }
    public DateTime ExpiresAtUtc { get; init; }
}
