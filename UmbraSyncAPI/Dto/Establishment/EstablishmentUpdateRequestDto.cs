using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

[MessagePackObject(keyAsPropertyName: true)]
public record EstablishmentUpdateRequestDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int Category { get; init; }
    public string[] Languages { get; init; } = ["FR"];
    public string[] Tags { get; init; } = [];
    public string? FactionTag { get; init; }
    public string? Schedule { get; init; }
    public bool IsPublic { get; init; } = true;
    public string? LogoImageBase64 { get; init; }
    public string? BannerImageBase64 { get; init; }
    public EstablishmentLocationDto? Location { get; init; }
}
