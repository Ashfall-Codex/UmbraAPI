using MessagePack;
using UmbraSync.API.Data.Enum;

namespace UmbraSync.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record BulkPermissionsDto(Dictionary<string, UserPermissions> AffectedUsers, Dictionary<string, UserPermissions> AffectedGroups)
{
    public Dictionary<string, UserPermissions> AffectedUsers { get; set; } = AffectedUsers;
    public Dictionary<string, UserPermissions> AffectedGroups { get; set; } = AffectedGroups;
}
