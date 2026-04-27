using MessagePack;

namespace UmbraSync.API.Dto.Establishment;

[MessagePackObject(keyAsPropertyName: true)]
public record EstablishmentListRequestDto
{
    public int? Category { get; init; }
    public string[]? Languages { get; init; }
    public string[]? Tags { get; init; }
    public string? SearchText { get; init; }
    public int Page { get; init; } = 0;
    public int PageSize { get; init; } = 20;
}
