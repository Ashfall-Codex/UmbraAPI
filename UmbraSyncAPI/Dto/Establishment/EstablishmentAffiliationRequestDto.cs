using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

[MessagePackObject(keyAsPropertyName: true)]
public record EstablishmentAffiliationRequestDto
{
    public Guid EstablishmentId { get; init; }
    public int RpProfileId { get; init; }
    public string? Message { get; init; }
}

public enum EstablishmentAffiliationRequestResult
{
    Requested,
    Accepted,
    NotFound,
    AlreadyExists,
    LimitReached,
    PendingLimitReached,
    RateLimited
}

public static class EstablishmentAffiliationLimits
{
    public const int MaxDisplayedPerCharacter = 3;
    public const int MaxPendingPerCharacter = 5;
    public const int MaxMessageLength = 200;
}
