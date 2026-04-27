using MessagePack;

namespace UmbraSync.API.Dto.WildRp;

[MessagePackObject(keyAsPropertyName: true)]
public record WildRpListRequestDto
{
    public uint? WorldId { get; init; }
    public int Page { get; init; } = 0;
    public int PageSize { get; init; } = 20;
}
