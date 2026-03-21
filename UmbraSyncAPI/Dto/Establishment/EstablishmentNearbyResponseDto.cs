using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

[MessagePackObject(keyAsPropertyName: true)]
public record EstablishmentNearbyResponseDto
{
    public List<EstablishmentDto> Establishments { get; init; } = [];
}
