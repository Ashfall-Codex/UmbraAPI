using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

[MessagePackObject(keyAsPropertyName: true)]
public record EstablishmentEventDto
{
    public Guid Id { get; init; }
    public Guid EstablishmentId { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime StartsAtUtc { get; init; }
    public DateTime? EndsAtUtc { get; init; }
    public int Recurrence { get; init; }
    public DateTime CreatedUtc { get; init; }
}
