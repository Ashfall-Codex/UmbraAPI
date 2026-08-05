using MessagePack;

namespace UmbraSync.API.Dto.Rgpd;

[MessagePackObject]
public class RgpdDataExportDto
{
    [Key(0)] public string UID { get; set; } = string.Empty;
    [Key(1)] public string? Alias { get; set; }
    [Key(2)] public DateTime LastLoggedIn { get; set; }
    [Key(3)] public DateTime ExportDate { get; set; }
    [Key(4)] public int PairCount { get; set; }
    [Key(5)] public List<string> PairedUIDs { get; set; } = [];
    [Key(6)] public int GroupCount { get; set; }
    [Key(7)] public List<string> GroupGIDs { get; set; } = [];
    [Key(8)] public bool HasProfile { get; set; }
    [Key(9)] public string? ProfileDescription { get; set; }
    [Key(10)] public int RpProfileCount { get; set; }
    [Key(11)] public List<RgpdRpProfileSummaryDto> RpProfiles { get; set; } = [];
    [Key(12)] public int CharaDataCount { get; set; }
    [Key(13)] public int McdfShareCount { get; set; }
    [Key(14)] public int HousingShareCount { get; set; }
    [Key(15)] public int UploadedFileCount { get; set; }
    [Key(16)] public bool HasLodestoneAuth { get; set; }
    [Key(17)] public int SecondaryAccountCount { get; set; }

    // Clés 18+ : contenu détaillé ajouté pour satisfaire les droits d'accès et de portabilité
    // (RGPD art. 15 et 20). Les clés 0-17 restent inchangées pour la compatibilité MessagePack.
    [Key(18)] public string? ProfileImageBase64 { get; set; }
    [Key(19)] public bool ProfileIsNsfw { get; set; }
    [Key(20)] public bool ProfileDisabled { get; set; }
    [Key(21)] public List<RgpdEstablishmentDto> Establishments { get; set; } = [];
    [Key(22)] public List<RgpdWildRpAnnouncementDto> WildRpAnnouncements { get; set; } = [];
    [Key(23)] public List<RgpdShareSummaryDto> McdfShares { get; set; } = [];
    [Key(24)] public List<RgpdShareSummaryDto> HousingShares { get; set; } = [];
    [Key(25)] public List<RgpdShareSummaryDto> HousingScenarios { get; set; } = [];
    [Key(26)] public List<RgpdCharaDataSummaryDto> CharaData { get; set; } = [];
    [Key(27)] public List<RgpdUploadedFileDto> UploadedFiles { get; set; } = [];
    [Key(28)] public int EstablishmentCount { get; set; }
    [Key(29)] public int WildRpAnnouncementCount { get; set; }
    [Key(30)] public int HousingScenarioCount { get; set; }
    /// Rappelle que le contenu chiffré des partages n'est pas exportable : la clé ne quitte jamais le client.
    [Key(31)] public string? EncryptedContentNotice { get; set; }
    /// Rappelle qu'Ashfall Connect est un traitement distinct, à interroger séparément.
    [Key(32)] public string? ExternalServicesNotice { get; set; }
}

[MessagePackObject]
public class RgpdRpProfileSummaryDto
{
    [Key(0)] public string CharacterName { get; set; } = string.Empty;
    [Key(1)] public uint WorldId { get; set; }
    [Key(2)] public string? RpFirstName { get; set; }
    [Key(3)] public string? RpLastName { get; set; }

    // Clés 4+ : contenu complet de la fiche RP.
    [Key(4)] public string? RpTitle { get; set; }
    [Key(5)] public string? RpDescription { get; set; }
    [Key(6)] public string? RpProfilePictureBase64 { get; set; }
    [Key(7)] public string? RpAge { get; set; }
    [Key(8)] public string? RpRace { get; set; }
    [Key(9)] public string? RpEthnicity { get; set; }
    [Key(10)] public string? RpHeight { get; set; }
    [Key(11)] public string? RpBuild { get; set; }
    [Key(12)] public string? RpResidence { get; set; }
    [Key(13)] public string? RpOccupation { get; set; }
    [Key(14)] public string? RpAffiliation { get; set; }
    [Key(15)] public string? RpAlignment { get; set; }
    [Key(16)] public string? RpAdditionalInfo { get; set; }
    [Key(17)] public string? RpNameColor { get; set; }
    [Key(18)] public string? RpCustomFields { get; set; }
    [Key(19)] public string? MoodlesData { get; set; }
    [Key(20)] public string? EnrichedProfileJson { get; set; }
    [Key(21)] public string? EnrichedProfileVisibility { get; set; }
}

[MessagePackObject]
public class RgpdEstablishmentDto
{
    [Key(0)] public Guid Id { get; set; }
    [Key(1)] public string Name { get; set; } = string.Empty;
    [Key(2)] public string? Description { get; set; }
    [Key(3)] public int Category { get; set; }
    [Key(4)] public List<string> Languages { get; set; } = [];
    [Key(5)] public List<string> Tags { get; set; } = [];
    [Key(6)] public string? FactionTag { get; set; }
    [Key(7)] public string? Schedule { get; set; }
    [Key(8)] public bool IsPublic { get; set; }
    [Key(9)] public DateTime CreatedUtc { get; set; }
    [Key(10)] public DateTime UpdatedUtc { get; set; }
    [Key(11)] public int LocationType { get; set; }
    [Key(12)] public uint TerritoryId { get; set; }
    [Key(13)] public ulong? ServerId { get; set; }
    [Key(14)] public uint? WardId { get; set; }
    [Key(15)] public uint? PlotId { get; set; }
    [Key(16)] public uint? DivisionId { get; set; }
    [Key(17)] public uint? RoomId { get; set; }
    [Key(18)] public bool? IsApartment { get; set; }
    [Key(19)] public string? LogoImageBase64 { get; set; }
    [Key(20)] public string? BannerImageBase64 { get; set; }
    [Key(21)] public int? ManagerRpProfileId { get; set; }
    [Key(22)] public List<RgpdEstablishmentEventDto> Events { get; set; } = [];
}

[MessagePackObject]
public class RgpdEstablishmentEventDto
{
    [Key(0)] public Guid Id { get; set; }
    [Key(1)] public string Title { get; set; } = string.Empty;
    [Key(2)] public string? Description { get; set; }
    [Key(3)] public DateTime StartsAtUtc { get; set; }
    [Key(4)] public DateTime? EndsAtUtc { get; set; }
    [Key(5)] public int Recurrence { get; set; }
    [Key(6)] public DateTime CreatedUtc { get; set; }
}

[MessagePackObject]
public class RgpdWildRpAnnouncementDto
{
    [Key(0)] public Guid Id { get; set; }
    [Key(1)] public string? CharacterName { get; set; }
    [Key(2)] public uint WorldId { get; set; }
    [Key(3)] public uint TerritoryId { get; set; }
    [Key(4)] public uint? WardId { get; set; }
    [Key(5)] public string? Message { get; set; }
    [Key(6)] public int? RpProfileId { get; set; }
    [Key(7)] public DateTime CreatedAtUtc { get; set; }
    [Key(8)] public DateTime ExpiresAtUtc { get; set; }
}

/// Métadonnées d'un partage. Le contenu (CipherData) est chiffré côté client : le serveur
/// ne détient pas la clé et ne peut donc pas l'exporter en clair.
[MessagePackObject]
public class RgpdShareSummaryDto
{
    [Key(0)] public Guid Id { get; set; }
    [Key(1)] public string Description { get; set; } = string.Empty;
    [Key(2)] public DateTime CreatedUtc { get; set; }
    [Key(3)] public DateTime? UpdatedUtc { get; set; }
    [Key(4)] public DateTime? ExpiresAtUtc { get; set; }
    [Key(5)] public int DownloadCount { get; set; }
    [Key(6)] public List<string> AllowedUIDs { get; set; } = [];
    [Key(7)] public List<string> AllowedGIDs { get; set; } = [];
    [Key(8)] public int EncryptedPayloadSizeBytes { get; set; }
    [Key(9)] public uint? ServerId { get; set; }
    [Key(10)] public uint? TerritoryId { get; set; }
    [Key(11)] public uint? WardId { get; set; }
    [Key(12)] public uint? HouseId { get; set; }
    [Key(13)] public uint? RoomId { get; set; }
}

[MessagePackObject]
public class RgpdCharaDataSummaryDto
{
    [Key(0)] public string Id { get; set; } = string.Empty;
    [Key(1)] public string Description { get; set; } = string.Empty;
    [Key(2)] public DateTime CreatedDate { get; set; }
    [Key(3)] public DateTime UpdatedDate { get; set; }
    [Key(4)] public DateTime? ExpiryDate { get; set; }
    [Key(5)] public int DownloadCount { get; set; }
    [Key(6)] public int FileCount { get; set; }
    [Key(7)] public int PoseCount { get; set; }
    [Key(8)] public List<string> AllowedUIDs { get; set; } = [];
    [Key(9)] public List<string> AllowedGIDs { get; set; } = [];
}

[MessagePackObject]
public class RgpdUploadedFileDto
{
    [Key(0)] public string Hash { get; set; } = string.Empty;
    [Key(1)] public long Size { get; set; }
    [Key(2)] public DateTime UploadDate { get; set; }
}