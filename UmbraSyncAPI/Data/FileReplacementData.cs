using MessagePack;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace UmbraSync.API.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class FileReplacementData
{
    public FileReplacementData()
    {
        DataHash = new(() =>
        {
            var json = JsonSerializer.Serialize(this);
#pragma warning disable SYSLIB0021 // Type or member is obsolete
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(json)));
        });
    }

    [JsonIgnore]
    public Lazy<string> DataHash { get; }
    public string[] GamePaths { get; set; } = Array.Empty<string>();
    public string Hash { get; set; } = string.Empty;
    public string FileSwapPath { get; set; } = string.Empty;
    // BLAKE3 du contenu calculé par l'émetteur : le destinataire vérifie le fichier téléchargé de bout en bout.
    // Champ additif : un client ou un serveur qui ne le connaît pas ignore cette clé (MessagePack keyAsPropertyName).
    public string Blake3 { get; set; } = string.Empty;
}