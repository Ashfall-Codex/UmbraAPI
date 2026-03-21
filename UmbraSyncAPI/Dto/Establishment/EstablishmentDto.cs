using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

[MessagePackObject(keyAsPropertyName: true)]
public record EstablishmentDto
{
    public Guid Id { get; init; }
    public string OwnerUID { get; init; } = string.Empty;
    public string? OwnerAlias { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int Category { get; init; }
    public string[] Languages { get; init; } = ["FR"];
    public string[] Tags { get; init; } = [];
    public string? FactionTag { get; init; }
    public string? Schedule { get; init; }
    public bool IsPublic { get; init; } = true;
    public DateTime CreatedUtc { get; init; }
    public DateTime UpdatedUtc { get; init; }
    public string? LogoImageBase64 { get; init; }
    public string? BannerImageBase64 { get; init; }
    public int? ManagerRpProfileId { get; init; }
    public string? ManagerCharacterName { get; init; }
    public string? ManagerRpFirstName { get; init; }
    public string? ManagerRpLastName { get; init; }
    public string? ManagerRpProfilePictureBase64 { get; init; }
    public bool ShowManagerOnProfile { get; init; } = true;
    public EstablishmentLocationDto? Location { get; init; }
    public List<EstablishmentEventDto> Events { get; init; } = [];
}

public enum EstablishmentLocationType
{
    Housing,
    Zone
}

public enum EstablishmentCategory
{
    Taverne,
    Boutique,
    Temple,
    Academie,
    Guilde,
    Residence,
    Atelier,
    Autre
}
