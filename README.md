<p align="center">
  <img src="https://repo.ashfall-codex.dev/img/umbra-full.png" alt="UmbraSync API" width="96" />
</p>

<h1 align="center">UmbraSync API</h1>

<p align="center">
  Contrats partagés (interfaces SignalR, DTOs, modèles de données et routes) utilisés par le plugin <b>UmbraSync</b> et le serveur relay.
</p>

<p align="center">
  API <code>v3000</code> &middot; .NET 10 &middot; MessagePack
</p>

---

## Vue d'ensemble

Ce projet définit le contrat entre le client (plugin Dalamud) et le serveur (relay SignalR). Il ne contient aucune logique métier, uniquement :

- **Interfaces SignalR** : `IMareHub` (88 méthodes serveur) et `IMareHubClient` (30 callbacks client)
- **DTOs** : 57 classes/records de transfert de données, sérialisés en MessagePack
- **Modèles de données** : records et classes partagés (`UserData`, `GroupData`, `CharacterData`, etc.)
- **Enums** : 9 enums dont 4 à flags pour les permissions
- **Routes** : constantes et URI builders pour les endpoints HTTP (auth, fichiers, cache, distribution)

---

## Structure

```
UmbraSyncAPI/
├── SignalR/
│   ├── IMareHub.cs              # Interface hub serveur (88 méthodes + constantes)
│   └── IMareHubClient.cs        # Interface callbacks client (30 méthodes)
├── Dto/
│   ├── Account/                 # RegisterReplyDto, RegisterReplyV2Dto
│   ├── CharaData/               # CharaDataDto, CharaDataFullDto, CharaDataDownloadDto, ...
│   ├── Files/                   # DownloadFileDto, UploadFileDto, FilesSendDto
│   ├── Group/                   # GroupDto, GroupInfoDto, GroupFullInfoDto, GroupProfileDto, ...
│   ├── User/                    # UserDto, UserPairDto, UserProfileDto, TypingStateDto, ...
│   ├── Slot/                    # SlotInfoResponseDto, SlotLocationDto, SlotUpdateRequestDto
│   ├── HousingShare/            # HousingShareEntryDto, HousingSharePayloadDto, ...
│   ├── McdfShare/               # McdfShareEntryDto, McdfSharePayloadDto, ...
│   ├── QuestSync/               # QuestSessionStateDto, QuestEventTriggerDto, ...
│   ├── Rgpd/                    # RgpdDataExportDto, RgpdRpProfileSummaryDto
│   ├── AuthReplyDto.cs
│   ├── ConnectionDto.cs
│   └── SystemInfoDto.cs
├── Data/
│   ├── UserData.cs              # Record utilisateur (UID, Alias)
│   ├── GroupData.cs             # Record groupe (GID, Alias)
│   ├── CharacterData.cs         # Données personnage (apparence, mods, moodles, etc.)
│   ├── FileReplacementData.cs   # Remplacement de fichier avec hash SHA-256 lazy
│   ├── RpCustomField.cs         # Champ RP personnalisé
│   ├── Enum/                    # 9 enums (permissions, scopes, sévérité, etc.)
│   ├── Extensions/              # Méthodes d'extension pour les enums à flags
│   └── Comparer/                # Comparateurs d'égalité (UserData, GroupData, etc.)
├── Routes/
│   ├── MareAuth.cs              # Routes d'authentification + URI builders
│   └── MareFiles.cs             # Routes fichiers, cache, distribution + URI builders
└── UmbraSync.API.csproj
```

---

## SignalR Hub (`IMareHub`)

**Hub path** : `/mare`
**Version API** : `3000`

### Méthodes serveur (client -> serveur) — 88 méthodes

| Domaine | Méthodes | Description |
|---|---|---|
| Connexion | `CheckClientHealth`, `GetConnectionDto` | Santé et info de connexion |
| Groupes | `GroupCreate`, `GroupCreateTemporary`, `GroupJoin`, `GroupLeave`, `GroupDelete`, `GroupChangePassword`, `GroupClear`, `GroupCreateTempInvite`, `GroupsGetAll`, `GroupsGetUsersInGroup`, `GroupChangeOwnership`, `GroupRemoveUser`, `GroupChangeGroupPermissionState`, `GroupChangeIndividualPermissionState`, `GroupSetUserInfo`, `GroupGetBannedUsers`, `GroupBanUser`, `GroupUnbanUser`, `GroupPrune`, `GroupGetProfile`, `GroupSetProfile` | CRUD complet des Syncshells |
| Paires | `UserAddPair`, `UserRemovePair`, `UserGetPairedClients`, `UserGetOnlinePairs`, `UserSetPairPermissions`, `UserPushData` | Appairage et synchronisation |
| Profils | `UserSetProfile`, `UserGetProfile`, `UserGetAllCharacterProfiles`, `UserReportProfile` | Profils RP et classiques |
| Typing | `UserSetTypingState`, `UserSetTypingStateEx`, `UserUpdateTypingChannels` | Indicateurs de saisie |
| CharaData | `CharaDataCreate`, `CharaDataUpdate`, `CharaDataDelete`, `CharaDataGetMetainfo`, `CharaDataDownload`, `CharaDataGetOwn`, `CharaDataGetShared`, `CharaDataAttemptRestore` | Gestion MCDF |
| Gpose | `GposeLobbyCreate`, `GposeLobbyJoin`, `GposeLobbyLeave`, `GposeLobbyPushCharacterData`, `GposeLobbyPushPoseData`, `GposeLobbyPushWorldData` | Gpose Together |
| Discovery | `SyncshellDiscoveryList`, `SyncshellDiscoveryGetState`, `SyncshellDiscoverySetVisibility`, `SyncshellDiscoverySetPolicy`, `SyncshellDiscoveryJoin` | Annuaire SyncFinder |
| Slots | `SlotGetInfo`, `SlotGetNearby`, `SlotUpdate`, `SlotGetInfoForGroup`, `SlotJoin` | Housing slots |
| Housing | `HousingShareUpload`, `HousingShareDownload`, `HousingShareGetOwn`, `HousingShareGetForLocation`, `HousingShareUpdate`, `HousingShareDelete` | Partage de housing |
| Quêtes | `QuestSessionCreate`, `QuestSessionJoin`, `QuestSessionLeave`, `QuestSessionPushState`, `QuestSessionTriggerEvent`, `QuestSessionBranchingChoice` | Synchronisation de quêtes |
| RGPD | `UserRgpdExportData`, `UserRgpdDeleteAllData` | Conformité RGPD |
| Compte | `UserDelete` | Suppression de compte |

### Callbacks client (serveur -> client) — 30 méthodes

| Domaine | Callbacks |
|---|---|
| Groupes | `Client_GroupDelete`, `Client_GroupSendInfo`, `Client_GroupSendFullInfo`, `Client_GroupSendProfile`, `Client_GroupChangePermissions`, `Client_GroupPairJoined`, `Client_GroupPairLeft`, `Client_GroupPairChangeUserInfo`, `Client_GroupPairChangePermissions` |
| Utilisateurs | `Client_UserSendOnline`, `Client_UserSendOffline`, `Client_UserAddClientPair`, `Client_UserRemoveClientPair`, `Client_UserUpdateProfile`, `Client_UserUpdateSelfPairPermissions`, `Client_UserUpdateOtherPairPermissions`, `Client_UserReceiveCharacterData`, `Client_UserReceiveUploadStatus`, `Client_UserTypingState` |
| Gpose | `Client_GposeLobbyJoin`, `Client_GposeLobbyLeave`, `Client_GposeLobbyPushCharacterData`, `Client_GposeLobbyPushPoseData`, `Client_GposeLobbyPushWorldData` |
| Quêtes | `Client_QuestSessionJoin`, `Client_QuestSessionLeave`, `Client_QuestSessionStateUpdate`, `Client_QuestSessionEventTriggered`, `Client_QuestSessionBranchingChoice` |
| Système | `Client_ReceiveServerMessage`, `Client_UpdateSystemInfo`, `Client_DownloadReady` |

---

## DTOs par domaine

### Account (2)

| DTO | Champs |
|---|---|
| `RegisterReplyDto` | Success, ErrorMessage, UID, SecretKey |
| `RegisterReplyV2Dto` | Success, ErrorMessage, UID |

### User (11)

| DTO | Champs |
|---|---|
| `UserDto` | User (`UserData`), CharacterName, WorldId |
| `UserPairDto` | *+ OwnPermissions, OtherPermissions* |
| `UserPermissionsDto` | *+ Permissions* |
| `UserProfileDto` | *+ Disabled, IsNSFW, ProfilePictureBase64, Description, 13 champs RP (RpFirstName, RpLastName, RpTitle, RpAge, RpRace, RpEthnicity, RpHeight, RpBuild, RpResidence, RpOccupation, RpAffiliation, RpAlignment, RpAdditionalInfo), RpNameColor, RpCustomFields, MoodlesData* |
| `UserProfileReportDto` | *+ ProfileReport* |
| `OnlineUserIdentDto` | *+ Ident* |
| `OnlineUserCharaDataDto` | *+ CharaData* |
| `UserCharaDataMessageDto` | Recipients, CharaData |
| `TypingStateDto` | User, IsTyping, Scope |
| `TypingStateExDto` | IsTyping, Scope, TargetUid, ChannelId |
| `TypingChannelsDto` | PartyId, AllianceId, FreeCompanyId, CrossPartyIds, CustomGroupIds, ProximityEnabled |

### Group (15)

| DTO | Champs |
|---|---|
| `GroupDto` | Group (`GroupData`), GID, GroupAlias, GroupAliasOrGID |
| `GroupInfoDto` | *+ Owner, GroupPermissions, MaxUserCount, AutoDetectVisible, PasswordTemporarilyDisabled, OwnerUID, OwnerAlias, IsTemporary, ExpiresAt* |
| `GroupFullInfoDto` | *+ GroupUserPermissions, GroupUserInfo* |
| `GroupPairDto` | Group, User, UID, UserAlias, UserAliasOrUID |
| `GroupPairFullInfoDto` | *+ GroupPairStatusInfo, GroupUserPermissions* |
| `GroupPairUserInfoDto` | *+ GroupUserInfo* |
| `GroupPairUserPermissionDto` | *+ GroupPairPermissions* |
| `GroupPasswordDto` | *+ Password, IsTemporary, ExpiresAt* |
| `GroupPermissionDto` | *+ Permissions* |
| `GroupProfileDto` | Group, Description, Tags, ProfileImageBase64, BannerImageBase64, IsNsfw, IsDisabled |
| `BannedGroupUserDto` | *+ Reason, BannedOn, BannedBy* |
| `SyncshellDiscoveryEntryDto` | GID, Alias, OwnerUID, OwnerAlias, MemberCount, AutoAcceptPairs, Description, MaxUserCount, IsNsfw, Tags |
| `SyncshellDiscoveryStateDto` | GID, AutoDetectVisible, PasswordTemporarilyDisabled, Mode, DisplayDurationHours, ActiveWeekdays, TimeStartLocal, TimeEndLocal, TimeZone |
| `SyncshellDiscoveryVisibilityRequestDto` | GID, AutoDetectVisible, DisplayDurationHours, ActiveWeekdays, TimeStartLocal, TimeEndLocal, TimeZone |
| `SyncshellDiscoverySetPolicyRequestDto` | GID, Mode, DisplayDurationHours, ActiveWeekdays, TimeStartLocal, TimeEndLocal, TimeZone |

### CharaData (7)

| DTO | Champs |
|---|---|
| `CharaDataDto` | Id, Uploader, Description, UpdatedDate |
| `CharaDataDownloadDto` | *+ GlamourerData, CustomizeData, ManipulationData, FileGamePaths, FileSwaps* |
| `CharaDataFullDto` | *+ CreatedDate, ExpiryDate, DownloadCount, AllowedUsers, AllowedGroups, OriginalFiles, AccessType, ShareType, PoseData* |
| `CharaDataMetaInfoDto` | *+ CanBeDownloaded, PoseData* |
| `CharaDataUpdateDto` | Id, Description, ExpiryDate, GlamourerData, CustomizeData, ManipulationData, AllowedUsers, AllowedGroups, FileGamePaths, FileSwaps, AccessType, ShareType, Poses |

**Structures imbriquées** : `GamePathEntry`, `PoseEntry`, `WorldData`, `LocationInfo`, `PoseData`, `BoneData`

### Files (3 + 1 interface)

| DTO | Champs |
|---|---|
| `ITransferFileDto` | Hash, IsForbidden, ForbiddenBy *(interface)* |
| `DownloadFileDto` | FileExists, Hash, Url, DirectDownloadUrl, Size, IsForbidden, ForbiddenBy |
| `UploadFileDto` | Hash, IsForbidden, ForbiddenBy |
| `FilesSendDto` | FileHashes, UIDs |

### Slot (4), HousingShare (4), McdfShare (4), QuestSync (3), RGPD (2)

Voir les fichiers sources pour le détail des champs.

---

## Enums

| Enum | Type | Valeurs |
|---|---|---|
| `MessageSeverity` | — | Information, Warning, Error |
| `ObjectKind` | — | Player, MinionOrMount, Companion, Pet |
| `UserPermissions` | Flags | Paired, Paused, DisableAnimations, DisableSounds, DisableVFX, DisableHousing |
| `GroupPermissions` | Flags | DisableAnimations, DisableSounds, DisableInvites, DisableVFX, Paused |
| `GroupUserPermissions` | Flags | Paused, DisableAnimations, DisableSounds, DisableVFX, DisableHousing |
| `GroupUserInfo` | Flags | IsModerator, IsPinned |
| `TypingScope` | — | Unknown, Proximity, Party, CrossParty, FreeCompany, Alliance, Whisper |
| `QuestTriggerType` | — | NormalInteraction, DoEmote, SayPhrase, SubObjectivesFinished, KillEnemy, BoundingTrigger |
| `AutoDetectMode` | — | Off, Duration, Recurring, Fulltime |

Chaque enum à flags dispose de méthodes d'extension (`Is*()` / `Set*()`) dans `Data/Extensions/`.

---

## Routes HTTP

### Authentification (`MareAuth`)

| Route | Description |
|---|---|
| `POST /auth/createWithIdentV2` | Création de compte avec identification |
| `POST /auth/registerNewKeyV2` | Renouvellement de clé secrète |

### Fichiers (`MareFiles`)

| Route | Description |
|---|---|
| `GET /cache/get/{requestId}` | Téléchargement depuis le cache |
| `POST /request/enqueue` | Mise en file d'attente d'un fichier |
| `GET /request/check` | Vérification du statut de la file |
| `DELETE /request/cancel` | Annulation d'une requête |
| `POST /request/file` | Requête de fichier |
| `POST /files/upload` | Upload de fichier |
| `POST /files/uploadRaw` | Upload brut |
| `POST /files/uploadMunged` | Upload encodé |
| `POST /files/filesSend` | Envoi de fichiers à des paires |
| `POST /files/getFileSizes` | Taille des fichiers |
| `DELETE /files/deleteAll` | Suppression de tous les fichiers |
| `GET /dist/get` | Téléchargement distribué |
| `POST /main/sendReady` | Signal de téléchargement prêt |

---

## Sérialisation

Tous les DTOs utilisent **MessagePack** (`[MessagePackObject(keyAsPropertyName: true)]`) pour une sérialisation binaire performante. Les structures imbriquées (`WorldData`, `PoseData`, `BoneData`, `LocationInfo`) sont des `record struct` pour un passage par valeur efficace.

---

## Patterns notables

- **Héritage de DTOs** : hiérarchie d'héritage pour éviter la duplication (`UserDto` -> `UserPairDto` -> etc.)
- **Hash SHA-256 lazy** : `CharacterData` et `FileReplacementData` calculent leur hash à la demande
- **Comparateurs singleton** : `UserDataComparer.Instance`, `GroupDataComparer.Instance`, etc.
- **URI builders** : méthodes statiques dans `MareFiles` pour construire les URIs complètes à partir d'une base

---

## Build

```bash
dotnet build UmbraSyncAPI/UmbraSync.API.csproj
```

**Dépendance** : `MessagePack` 2.5.187

**Target** : .NET 10.0 (avec support .NET 9.0)

---

## Licence

Le code original est sous licence MIT (voir `LICENSE_MIT`). A partir du commit `46f2443`, le code est sous licence **AGPL v3** (voir `LICENSE`).
