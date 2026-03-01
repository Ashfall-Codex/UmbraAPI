using MessagePack;

namespace UmbraSync.API.Dto.Rgpd;

[MessagePackObject]
public class RgpdDataExportDto
{
    [Key(0)] public string UID { get; set; } = string.Empty;
    [Key(1)] public string? Alias { get; set; }
    [Key(2)] public DateTime LastLoggedIn { get; set; }
    [Key(3)] public DateTime ExportDate { get; set; }
    [Key(4)] public int PairCount { get; set; }
    [Key(5)] public List<string> PairedUIDs { get; set; } = [];
    [Key(6)] public int GroupCount { get; set; }
    [Key(7)] public List<string> GroupGIDs { get; set; } = [];
    [Key(8)] public bool HasProfile { get; set; }
    [Key(9)] public string? ProfileDescription { get; set; }
    [Key(10)] public int RpProfileCount { get; set; }
    [Key(11)] public List<RgpdRpProfileSummaryDto> RpProfiles { get; set; } = [];
    [Key(12)] public int CharaDataCount { get; set; }
    [Key(13)] public int McdfShareCount { get; set; }
    [Key(14)] public int HousingShareCount { get; set; }
    [Key(15)] public int UploadedFileCount { get; set; }
    [Key(16)] public bool HasLodestoneAuth { get; set; }
    [Key(17)] public int SecondaryAccountCount { get; set; }
}

[MessagePackObject]
public class RgpdRpProfileSummaryDto
{
    [Key(0)] public string CharacterName { get; set; } = string.Empty;
    [Key(1)] public uint WorldId { get; set; }
    [Key(2)] public string? RpFirstName { get; set; }
    [Key(3)] public string? RpLastName { get; set; }
}
