using MessagePack;

namespace UmbraSync.API.Dto.StageShare;

[MessagePackObject]
public record struct StageLocationDto(
    [property: Key(0)] uint WorldId,
    [property: Key(1)] ushort TerritoryId,
    [property: Key(2)] int WardId,
    [property: Key(3)] int DivisionId,
    [property: Key(4)] int HouseId,
    [property: Key(5)] int RoomId);
