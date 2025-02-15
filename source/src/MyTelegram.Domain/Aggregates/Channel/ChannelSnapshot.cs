﻿namespace MyTelegram.Domain.Aggregates.Channel;

public class ChannelSnapshot(
    bool broadcast,
    long channelId,
    long creatorUid,
    long? photoId,
    bool preHistoryHidden,
    int maxMessageId,
    IReadOnlyList<long> botUidList,
    long latestNoneBotSenderPeerId,
    int latestNoneBotSenderMessageId,
    ChatBannedRights? defaultBannedRights,
    int slowModeSeconds,
    int lastSendDate,
    IReadOnlyList<ChatAdmin> adminList,
    int pinnedMsgId,
    byte[]? photo,
    long? linkedChannelId,
    string? userName,
    bool forum,
    int maxTopicId,
    int? ttlPeriod,
    long? migratedFromChatId,
    int? migratedMaxId,
    bool noForwards,
    bool isFirstChatInviteCreated,
    int? requestsPending,
    List<long>? recentRequesters,
    bool signatureEnabled,
    int participantCount,
    PeerColor? color,
    bool hasLink)
    : ISnapshot
{
    //bool megaGroup,
    //long lastSenderPeerId,
    //MegaGroup = megaGroup;
    //LastSenderPeerId = lastSenderPeerId;

    //public long LastSenderPeerId { get; private set; }
    public IReadOnlyList<ChatAdmin> AdminList { get; } = adminList;
    public IReadOnlyList<long> BotUidList { get; } = botUidList;

    public bool Broadcast { get; } = broadcast;

    //public bool MegaGroup { get; }
    public long ChannelId { get; } = channelId;

    public long CreatorUid { get; } = creatorUid;
    public long? PhotoId { get; } = photoId;
    public ChatBannedRights? DefaultBannedRights { get; } = defaultBannedRights;

    public int LastSendDate { get; } = lastSendDate;
    public int LatestNoneBotSenderMessageId { get; } = latestNoneBotSenderMessageId;

    public long LatestNoneBotSenderPeerId { get; } = latestNoneBotSenderPeerId;
    public long? LinkedChannelId { get; } = linkedChannelId;
    public int MaxMessageId { get; } = maxMessageId;
    public byte[]? Photo { get; } = photo;
    public int PinnedMsgId { get; } = pinnedMsgId;
    public bool PreHistoryHidden { get; } = preHistoryHidden;
    public int SlowModeSeconds { get; } = slowModeSeconds;
    public string? UserName { get; } = userName;
    public bool Forum { get; } = forum;
    public int MaxTopicId { get; } = maxTopicId;
    public int? TtlPeriod { get; } = ttlPeriod;
    public long? MigratedFromChatId { get; } = migratedFromChatId;
    public int? MigratedMaxId { get; } = migratedMaxId;
    public bool NoForwards { get; } = noForwards;
    public bool IsFirstChatInviteCreated { get; } = isFirstChatInviteCreated;
    public int? RequestsPending { get; } = requestsPending;
    public List<long>? RecentRequesters { get; } = recentRequesters;
    public bool SignatureEnabled { get; } = signatureEnabled;
    public int ParticipantCount { get; } = participantCount;
    public PeerColor? Color { get; } = color;
    public bool HasLink { get; } = hasLink;
}
