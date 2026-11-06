using MessagePack;

namespace UmbraSync.API.Dto.StageShare;

[MessagePackObject]
public class StageShareUploadRequestDto
{
    [Key(0)] public Guid ShareId { get; set; }
    [Key(1)] public StageLocationDto Location { get; set; }
    [Key(2)] public string Description { get; set; } = string.Empty;
    [Key(3)] public byte[] CipherData { get; set; } = [];
    [Key(4)] public byte[] Nonce { get; set; } = [];
    [Key(5)] public byte[] Salt { get; set; } = [];
    [Key(6)] public byte[] Tag { get; set; } = [];
    [Key(7)] public List<string> AllowedIndividuals { get; set; } = [];
    [Key(8)] public List<string> AllowedSyncshells { get; set; } = [];
    [Key(9)] public string StageName { get; set; } = string.Empty;
    [Key(10)] public int StageFormatVersion { get; set; }
}
