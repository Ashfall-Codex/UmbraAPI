using MessagePack;

namespace UmbraSync.API.Dto.WildRp;

[MessagePackObject(keyAsPropertyName: true)]
public record WildRpListResponseDto
{
    public List<WildRpAnnouncementDto> Announcements { get; init; } = [];
    public int TotalCount { get; init; }
    public int Page { get; init; }
    public int PageSize { get; init; }
}
