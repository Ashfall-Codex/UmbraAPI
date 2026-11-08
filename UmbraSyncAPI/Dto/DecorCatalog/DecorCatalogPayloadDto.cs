using MessagePack;

namespace UmbraSync.API.Dto.DecorCatalog;

[MessagePackObject]
public class DecorCatalogPayloadDto
{
    [Key(0)] public Guid Id { get; set; }
    [Key(1)] public byte[] Content { get; set; } = [];
    [Key(2)] public float AnchorX { get; set; }
    [Key(3)] public float AnchorY { get; set; }
    [Key(4)] public float AnchorZ { get; set; }
    [Key(5)] public int StageFormatVersion { get; set; }
}
