using MessagePack;
using UmbraSync.API.Data;

namespace UmbraSync.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupAliasDto(GroupData Group, string NewAlias) : GroupDto(Group);
