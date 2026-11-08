using MessagePack;

namespace UmbraSync.API.Dto.DecorCatalog;

[MessagePackObject]
public class DecorCatalogListRequestDto
{
    [Key(0)] public string? SearchText { get; set; }
    [Key(1)] public DecorCatalogSort Sort { get; set; }
    [Key(2)] public bool OnlyMine { get; set; }
    [Key(3)] public bool OnlyFavorites { get; set; }
    [Key(4)] public int Page { get; set; }
    [Key(5)] public int PageSize { get; set; } = 24;
}
