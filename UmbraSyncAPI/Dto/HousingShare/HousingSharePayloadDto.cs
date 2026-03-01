using MessagePack;

namespace UmbraSync.API.Dto.HousingShare;

[MessagePackObject]
public class HousingSharePayloadDto
{
    [Key(0)] public Guid ShareId { get; set; }
    [Key(1)] public byte[] CipherData { get; set; } = [];
    [Key(2)] public byte[] Nonce { get; set; } = [];
    [Key(3)] public byte[] Salt { get; set; } = [];
    [Key(4)] public byte[] Tag { get; set; } = [];
}
