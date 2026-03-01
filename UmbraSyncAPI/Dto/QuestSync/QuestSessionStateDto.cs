using MessagePack;

namespace UmbraSync.API.Dto.QuestSync;

[MessagePackObject]
public class QuestSessionStateDto
{
    [Key(0)] public string QuestId { get; set; } = string.Empty;
    [Key(1)] public int CurrentObjectiveIndex { get; set; }
    [Key(2)] public int CurrentEventIndex { get; set; }
    [Key(3)] public List<string> CompletedObjectiveIds { get; set; } = [];
}
