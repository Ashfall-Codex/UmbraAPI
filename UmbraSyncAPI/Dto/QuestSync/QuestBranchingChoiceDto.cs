using MessagePack;

namespace UmbraSync.API.Dto.QuestSync;

[MessagePackObject]
public class QuestBranchingChoiceDto
{
    [Key(0)] public string ObjectiveId { get; set; } = string.Empty;
    [Key(1)] public int ChoiceIndex { get; set; }
    [Key(2)] public int? DiceRollResult { get; set; }
    [Key(3)] public int ResultEventIndex { get; set; }
}
