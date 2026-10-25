using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

public enum EstablishmentAffiliationStatus
{
    Pending,
    Accepted,
    Refused
}

[MessagePackObject(keyAsPropertyName: true)]
public record EstablishmentAffiliationDto
{
    public Guid Id { get; init; }
    public Guid EstablishmentId { get; init; }
    public string EstablishmentName { get; init; } = string.Empty;
    public string UserUID { get; init; } = string.Empty;
    public string? UserAlias { get; init; }
    public int RpProfileId { get; init; }
    public string CharacterName { get; init; } = string.Empty;
    public uint WorldId { get; init; }
    public string? RpFirstName { get; init; }
    public string? RpLastName { get; init; }
    public string? RpProfilePictureBase64 { get; init; }
    public EstablishmentAffiliationStatus Status { get; init; }
    public bool ShowOnProfile { get; init; } = true;
    public string? Message { get; init; }
    public DateTime RequestedUtc { get; init; }
}
