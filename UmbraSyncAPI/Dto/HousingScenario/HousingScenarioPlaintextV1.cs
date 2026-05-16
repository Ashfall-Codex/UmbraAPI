using MessagePack;

namespace UmbraSync.API.Dto.HousingScenario;

[MessagePackObject]
public class HousingScenarioPlaintextV1
{
    [Key(0)] public string ScenarioJson { get; set; } = string.Empty;
    [Key(1)] public int ArrFormatVersion { get; set; }
    [Key(2)] public string OriginalFileName { get; set; } = string.Empty;
}
