﻿namespace MyTelegram.Domain.Events.Channel;

public class ChannelAdminRightsEditedEvent(
    RequestInfo requestInfo,
    long channelId,
    long promotedBy,
    bool canEdit,
    long userId,
    bool isBot,
    bool isNewAdmin,
    ChatAdminRights adminRights,
    string rank,
    bool removeAdminFromList,
    int date)
    : RequestAggregateEvent2<ChannelAggregate, ChannelId>(requestInfo)
{
    public ChatAdminRights AdminRights { get; } = adminRights;
    public bool CanEdit { get; } = canEdit;

    public long ChannelId { get; } = channelId;
    public long PromotedBy { get; } = promotedBy;

    /// <summary>
    ///     The role (rank) of the admin in the group: just an arbitrary string, admin by default
    /// </summary>
    public string Rank { get; } = rank;

    public bool RemoveAdminFromList { get; } = removeAdminFromList;
    public int Date { get; } = date;

    public long UserId { get; } = userId;
    public bool IsBot { get; } = isBot;
    public bool IsNewAdmin { get; } = isNewAdmin;
}
