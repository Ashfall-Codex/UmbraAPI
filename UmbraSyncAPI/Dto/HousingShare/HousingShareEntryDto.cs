using MessagePack;
using UmbraSync.API.Dto.CharaData;

namespace UmbraSync.API.Dto.HousingShare;

[MessagePackObject]
public class HousingShareEntryDto
{
    [Key(0)] public Guid Id { get; set; }
    [Key(1)] public LocationInfo Location { get; set; }
    [Key(2)] public string Description { get; set; } = string.Empty;
    [Key(3)] public DateTime CreatedUtc { get; set; }
    [Key(4)] public DateTime? UpdatedUtc { get; set; }
    [Key(5)] public bool IsOwner { get; set; }
    [Key(6)] public string OwnerUid { get; set; } = string.Empty;
    [Key(7)] public string OwnerAlias { get; set; } = string.Empty;
}
