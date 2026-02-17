using MessagePack;
using UmbraSync.API.Dto.CharaData;

namespace UmbraSync.API.Dto.HousingShare;

[MessagePackObject]
public class HousingShareUploadRequestDto
{
    [Key(0)] public Guid ShareId { get; set; }
    [Key(1)] public LocationInfo Location { get; set; }
    [Key(2)] public string Description { get; set; } = string.Empty;
    [Key(3)] public byte[] CipherData { get; set; } = Array.Empty<byte>();
    [Key(4)] public byte[] Nonce { get; set; } = Array.Empty<byte>();
    [Key(5)] public byte[] Salt { get; set; } = Array.Empty<byte>();
    [Key(6)] public byte[] Tag { get; set; } = Array.Empty<byte>();
}
