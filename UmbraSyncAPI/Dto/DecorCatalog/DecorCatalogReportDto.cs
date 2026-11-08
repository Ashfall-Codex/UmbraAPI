using MessagePack;

namespace UmbraSync.API.Dto.DecorCatalog;

[MessagePackObject]
public class DecorCatalogReportDto
{
    [Key(0)] public Guid Id { get; set; }
    [Key(1)] public string Reason { get; set; } = string.Empty;
}
