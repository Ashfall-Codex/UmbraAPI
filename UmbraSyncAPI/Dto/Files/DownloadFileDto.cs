using MessagePack;

namespace UmbraSync.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record DownloadFileDto : ITransferFileDto
{
    public bool FileExists { get; set; } = true;
    public string Hash { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string DirectDownloadUrl { get; set; } = string.Empty;
    public long Size { get; set; } = 0;
    public bool IsForbidden { get; set; } = false;
    public string ForbiddenBy { get; set; } = string.Empty;
    // Version BC7 alternative de ce fichier (compression server-side). null si aucune conversion disponible.
    // Champ additif : un client sans support BC7 ignore cette clé (MessagePack keyAsPropertyName).
    public DownloadFileDto? CompressedAlternateFileDownload { get; set; } = null;
    // true = le serveur a déterminé que ce fichier n'aura jamais d'alternate (non-texture, normal map exclue, échec définitif).
    public bool WillNotBeCompressed { get; set; } = false;
}