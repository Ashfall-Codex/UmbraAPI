using MessagePack;
using UmbraSync.API.Data;

namespace UmbraSync.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public sealed record GroupProfileDto
{
    public GroupData? Group { get; init; }
    public string? Description { get; init; }
    public string[]? Tags { get; init; }
    public string? ProfileImageBase64 { get; init; }
    public string? BannerImageBase64 { get; init; }
    public bool IsNsfw { get; init; }
    public bool IsDisabled { get; init; }
}
