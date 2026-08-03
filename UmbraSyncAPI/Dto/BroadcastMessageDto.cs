using MessagePack;
using UmbraSync.API.Data.Enum;

namespace UmbraSync.API.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public record BroadcastMessageDto
{
    public MessageSeverity Severity { get; set; } = MessageSeverity.Information;
    public string Message { get; set; } = string.Empty;
}
