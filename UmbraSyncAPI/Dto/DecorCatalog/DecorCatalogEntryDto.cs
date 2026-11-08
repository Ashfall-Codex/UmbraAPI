using MessagePack;

namespace UmbraSync.API.Dto.DecorCatalog;

[MessagePackObject]
public class DecorCatalogEntryDto
{
    [Key(0)] public Guid Id { get; set; }
    [Key(1)] public string Name { get; set; } = string.Empty;
    [Key(2)] public string Description { get; set; } = string.Empty;
    [Key(3)] public string OwnerUid { get; set; } = string.Empty;
    [Key(4)] public string OwnerAlias { get; set; } = string.Empty;
    [Key(5)] public bool IsOwner { get; set; }
    [Key(6)] public DateTime CreatedUtc { get; set; }
    [Key(7)] public DateTime? UpdatedUtc { get; set; }
    [Key(8)] public int StageFormatVersion { get; set; }
    [Key(9)] public int FileCount { get; set; }
    [Key(10)] public long TotalBytes { get; set; }
    [Key(11)] public int DisplayCount { get; set; }
    [Key(12)] public int FavoriteCount { get; set; }
    [Key(13)] public bool IsFavorite { get; set; }
    [Key(14)] public string? PreviewHash { get; set; }
}
