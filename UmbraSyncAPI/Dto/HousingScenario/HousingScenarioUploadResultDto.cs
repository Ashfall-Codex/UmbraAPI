using MessagePack;

namespace UmbraSync.API.Dto.HousingScenario;

public enum HousingScenarioUploadStatus
{
    Success = 0,
    Forbidden = 1,
    Conflict = 2,
}

[MessagePackObject]
public class HousingScenarioUploadResultDto
{
    [Key(0)] public HousingScenarioUploadStatus Status { get; set; }
    [Key(1)] public int ContentRevision { get; set; }
}
