using MessagePack;
using UmbraSync.API.Data.Enum;

namespace UmbraSync.API.Dto.QuestSync;

[MessagePackObject]
public class QuestEventTriggerDto
{
    [Key(0)] public QuestTriggerType TriggerType { get; set; }
    [Key(1)] public string ObjectiveId { get; set; } = string.Empty;
    [Key(2)] public string? TriggerData { get; set; }
    [Key(3)] public uint MonsterIndex { get; set; }
}
