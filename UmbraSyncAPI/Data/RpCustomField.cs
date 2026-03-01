using MessagePack;

namespace UmbraSync.API.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class RpCustomField
{
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public int Order { get; set; }
}
