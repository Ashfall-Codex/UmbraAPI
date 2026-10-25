using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

[MessagePackObject(keyAsPropertyName: true)]
public record EstablishmentProfileEntryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Category { get; init; }
    public string? Description { get; init; }
    public string? LogoImageBase64 { get; init; }
    public bool IsManager { get; init; }
}
