using MessagePack;
using UmbraSync.API.Data;
using UmbraSync.API.Dto.Group;

namespace UmbraSync.API.Dto.Ping;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupPingMarkerDto(GroupData Group, UserData Sender, PingMarkerDto Ping) : GroupDto(Group)
{
    public UserData Sender { get; set; } = Sender;
    public PingMarkerDto Ping { get; set; } = Ping;
}
