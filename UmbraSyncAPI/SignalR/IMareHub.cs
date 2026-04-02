using UmbraSync.API.Data;
using UmbraSync.API.Data.Enum;
using UmbraSync.API.Dto;
using UmbraSync.API.Dto.CharaData;
using UmbraSync.API.Dto.Rgpd;
using UmbraSync.API.Dto.Group;
using UmbraSync.API.Dto.HousingShare;
using UmbraSync.API.Dto.QuestSync;
using UmbraSync.API.Dto.Slot;
using UmbraSync.API.Dto.User;
using UmbraSync.API.Dto.WildRp;

namespace UmbraSync.API.SignalR;

public interface IMareHub
{
    const int ApiVersion = 3000;
    const string Path = "/mare";

    Task<bool> CheckClientHealth();

    Task Client_DownloadReady(Guid requestId);

    Task Client_GroupChangePermissions(GroupPermissionDto groupPermission);

    Task Client_GroupDelete(GroupDto groupDto);

    Task Client_GroupPairChangePermissions(GroupPairUserPermissionDto permissionDto);

    Task Client_GroupPairChangeUserInfo(GroupPairUserInfoDto userInfo);

    Task Client_GroupPairJoined(GroupPairFullInfoDto groupPairInfoDto);

    Task Client_GroupPairLeft(GroupPairDto groupPairDto);

    Task Client_GroupSendFullInfo(GroupFullInfoDto groupInfo);

    Task Client_GroupSendInfo(GroupInfoDto groupInfo);

    Task Client_ReceiveServerMessage(MessageSeverity messageSeverity, string message);

    Task Client_UpdateSystemInfo(SystemInfoDto systemInfo);

    Task Client_UserAddClientPair(UserPairDto dto);

    Task Client_ReceivePairRequest(UserDto requester);

    Task Client_UserReceiveCharacterData(OnlineUserCharaDataDto dataDto);

    Task Client_UserReceiveUploadStatus(UserDto dto);

    Task Client_UserRemoveClientPair(UserDto dto);

    Task Client_UserSendOffline(UserDto dto);

    Task Client_UserSendOnline(OnlineUserIdentDto dto);

    Task Client_UserUpdateOtherPairPermissions(UserPermissionsDto dto);

    Task Client_UserUpdateProfile(UserDto dto);

    Task Client_UserUpdateSelfPairPermissions(UserPermissionsDto dto);

    Task Client_UserTypingState(TypingStateDto dto);

    Task Client_GposeLobbyJoin(UserData userData);
    Task Client_GposeLobbyLeave(UserData userData);
    Task Client_GposeLobbyPushCharacterData(CharaDataDownloadDto charaDownloadDto);
    Task Client_GposeLobbyPushPoseData(UserData userData, PoseData poseData);
    Task Client_GposeLobbyPushWorldData(UserData userData, WorldData worldData);

    Task<ConnectionDto> GetConnectionDto();

    Task GroupBanUser(GroupPairDto dto, string reason);

    Task GroupChangeGroupPermissionState(GroupPermissionDto dto);

    Task GroupChangeIndividualPermissionState(GroupPairUserPermissionDto dto);

    Task GroupChangeOwnership(GroupPairDto groupPair);

    Task<bool> GroupChangePassword(GroupPasswordDto groupPassword);

    Task GroupClear(GroupDto group);

    Task<GroupPasswordDto> GroupCreate(string? alias);

    Task<GroupPasswordDto> GroupCreateTemporary(DateTime expiresAtUtc);

    Task<List<string>> GroupCreateTempInvite(GroupDto group, int amount);

    Task GroupDelete(GroupDto group);

    Task<List<BannedGroupUserDto>> GroupGetBannedUsers(GroupDto group);

    Task<bool> GroupJoin(GroupPasswordDto passwordedGroup);

    Task GroupLeave(GroupDto group);

    Task GroupRemoveUser(GroupPairDto groupPair);

    Task GroupSetUserInfo(GroupPairUserInfoDto groupPair);

    Task<List<GroupFullInfoDto>> GroupsGetAll();

    Task<List<GroupPairFullInfoDto>> GroupsGetUsersInGroup(GroupDto group);

    Task GroupUnbanUser(GroupPairDto groupPair);
    Task<int> GroupPrune(GroupDto group, int days, bool execute);

    Task UserAddPair(UserDto user);


    Task UserDelete();

    Task<List<OnlineUserIdentDto>> UserGetOnlinePairs();

    Task<List<UserPairDto>> UserGetPairedClients();

    Task<UserProfileDto> UserGetProfile(UserDto dto);

    Task<List<UserProfileDto>> UserGetAllCharacterProfiles(UserDto dto);

    Task UserPushData(UserCharaDataMessageDto dto);

    Task UserRemovePair(UserDto userDto);

    Task UserReportProfile(UserProfileReportDto userDto);

    Task UserSetPairPermissions(UserPermissionsDto userPermissions);

    Task UserSetProfile(UserProfileDto userDescription);

    Task UserSetTypingState(bool isTyping, TypingScope scope);
    Task UserSetTypingStateEx(TypingStateExDto dto);
    Task UserUpdateTypingChannels(TypingChannelsDto channels);
    Task<CharaDataFullDto?> CharaDataCreate();
    Task<CharaDataFullDto?> CharaDataUpdate(CharaDataUpdateDto updateDto);
    Task<bool> CharaDataDelete(string id);
    Task<CharaDataMetaInfoDto?> CharaDataGetMetainfo(string id);
    Task<CharaDataDownloadDto?> CharaDataDownload(string id);
    Task<List<CharaDataFullDto>> CharaDataGetOwn();
    Task<List<CharaDataMetaInfoDto>> CharaDataGetShared();
    Task<CharaDataFullDto?> CharaDataAttemptRestore(string id);

    Task<string> GposeLobbyCreate();
    Task<List<UserData>> GposeLobbyJoin(string lobbyId);
    Task<bool> GposeLobbyLeave();
    Task GposeLobbyPushCharacterData(CharaDataDownloadDto charaDownloadDto);
    Task GposeLobbyPushPoseData(PoseData poseData);
    Task GposeLobbyPushWorldData(WorldData worldData);
    Task<List<SyncshellDiscoveryEntryDto>> SyncshellDiscoveryList();
    Task<SyncshellDiscoveryStateDto?> SyncshellDiscoveryGetState(GroupDto group);
    Task<bool> SyncshellDiscoverySetVisibility(SyncshellDiscoveryVisibilityRequestDto request);
    Task<bool> SyncshellDiscoverySetPolicy(SyncshellDiscoverySetPolicyRequestDto request);
    Task<bool> SyncshellDiscoveryJoin(GroupDto group);
    Task<SlotInfoResponseDto?> SlotGetInfo(SlotLocationDto location);
    Task<SlotInfoResponseDto?> SlotGetNearby(uint serverId, uint territoryId, uint divisionId, uint wardId, float x, float y, float z);
    Task<bool> SlotUpdate(SlotUpdateRequestDto request);
    Task<List<SlotInfoResponseDto>> SlotGetInfoForGroup(GroupDto group);
    Task<bool> SlotJoin(Guid slotId);
    Task<GroupProfileDto?> GroupGetProfile(GroupDto group);
    Task GroupSetProfile(GroupProfileDto profile);
    Task Client_GroupSendProfile(GroupProfileDto profile);
    Task HousingShareUpload(HousingShareUploadRequestDto dto);
    Task<HousingSharePayloadDto?> HousingShareDownload(Guid shareId);
    Task<List<HousingShareEntryDto>> HousingShareGetOwn();
    Task<List<HousingShareEntryDto>> HousingShareGetForLocation(LocationInfo location);
    Task<HousingShareEntryDto?> HousingShareUpdate(HousingShareUpdateRequestDto dto);
    Task<bool> HousingShareDelete(Guid shareId);
    Task<string> QuestSessionCreate(string questId, string questName);
    Task<List<UserData>> QuestSessionJoin(string sessionId);
    Task<bool> QuestSessionLeave();
    Task QuestSessionPushState(QuestSessionStateDto state);
    Task QuestSessionTriggerEvent(QuestEventTriggerDto trigger);
    Task QuestSessionBranchingChoice(QuestBranchingChoiceDto choice);
    Task Client_QuestSessionJoin(UserData userData);
    Task Client_QuestSessionLeave(UserData userData);
    Task Client_QuestSessionStateUpdate(UserData sender, QuestSessionStateDto state);
    Task Client_QuestSessionEventTriggered(UserData sender, QuestEventTriggerDto trigger);
    Task Client_QuestSessionBranchingChoice(UserData sender, QuestBranchingChoiceDto choice);
    Task<RgpdDataExportDto?> UserRgpdExportData();
    Task UserRgpdDeleteAllData();
    Task Client_McdfShareReceived(string ownerUid, string description);

    Task<WildRpAnnouncementDto?> WildRpAnnounce(WildRpAnnounceRequestDto request);
    Task<bool> WildRpWithdraw();
    Task<WildRpListResponseDto> WildRpList(WildRpListRequestDto request);
    Task<WildRpAnnouncementDto?> WildRpGetOwn();
}