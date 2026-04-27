using MessagePack;
using UmbraSync.API.Data;
using UmbraSync.API.Data.Enum;

namespace UmbraSync.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserFullPairDto(UserData User, IndividualPairStatus IndividualPairStatus, List<string> GIDs, UserPermissions OwnPermissions, UserPermissions OtherPermissions) : UserDto(User)
{
    public IndividualPairStatus IndividualPairStatus { get; set; } = IndividualPairStatus;
    public List<string> GIDs { get; set; } = GIDs;
    public UserPermissions OwnPermissions { get; set; } = OwnPermissions;
    public UserPermissions OtherPermissions { get; set; } = OtherPermissions;
}
