using MessagePack;

namespace UmbraSync.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record DefaultPermissionsDto
{
    public bool DisableIndividualAnimations { get; set; }
    public bool DisableIndividualSounds { get; set; }
    public bool DisableIndividualVFX { get; set; }
    public bool DisableGroupAnimations { get; set; }
    public bool DisableGroupSounds { get; set; }
    public bool DisableGroupVFX { get; set; }
    public bool IndividualIsSticky { get; set; }
}
