using MessagePack;

namespace UmbraSync.API.Dto.DecorCatalog;

[MessagePackObject]
public class DecorCatalogPublishRequestDto
{
    [Key(0)] public Guid Id { get; set; }
    [Key(1)] public string Name { get; set; } = string.Empty;
    [Key(2)] public string Description { get; set; } = string.Empty;
    [Key(3)] public string? PreviewImageBase64 { get; set; }
    [Key(4)] public byte[] Content { get; set; } = [];
    [Key(5)] public float AnchorX { get; set; }
    [Key(6)] public float AnchorY { get; set; }
    [Key(7)] public float AnchorZ { get; set; }
    [Key(8)] public int AnchorTerritory { get; set; }
    [Key(9)] public int StageFormatVersion { get; set; }
    [Key(10)] public int FileCount { get; set; }
    [Key(11)] public long TotalBytes { get; set; }
}
