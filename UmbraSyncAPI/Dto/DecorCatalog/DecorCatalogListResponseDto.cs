using MessagePack;

namespace UmbraSync.API.Dto.DecorCatalog;

[MessagePackObject]
public class DecorCatalogListResponseDto
{
    [Key(0)] public List<DecorCatalogEntryDto> Entries { get; set; } = [];
    [Key(1)] public int TotalCount { get; set; }
    [Key(2)] public int Page { get; set; }
    [Key(3)] public int PageSize { get; set; }
}
