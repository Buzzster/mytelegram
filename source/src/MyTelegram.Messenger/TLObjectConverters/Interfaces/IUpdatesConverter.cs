﻿namespace MyTelegram.Messenger.TLObjectConverters.Interfaces;

public interface IUpdatesConverter : ILayeredConverter
{
    IUpdates ToMigrateChatUpdates(SendOutboxMessageCompletedEvent aggregateEvent, IChannelReadModel channelReadModel, IChatReadModel chatReadModel);
    IUpdates ToMigrateChatUpdates(ReceiveInboxMessageCompletedEvent aggregateEvent, long channelId);

    IUpdates ToChannelMessageUpdates(SendOutboxMessageCompletedEvent aggregateEvent, bool mentioned = false);

    IUpdates ToCreateChannelUpdates(ChannelCreatedEvent channelCreatedEvent,
        SendOutboxMessageCompletedEvent aggregateEvent);

    IUpdates ToCreateChatUpdates(ChatCreatedEvent chatCreatedAggregateEvent,
        SendOutboxMessageCompletedEvent aggregateEvent, IChatReadModel chatReadModel);

    IUpdates ToCreateChatUpdates(ChatCreatedEvent eventData,
        ReceiveInboxMessageCompletedEvent aggregateEvent, IChatReadModel chatReadModel);

    IUpdates ToDeleteMessagesUpdates(PeerType toPeerType,
        DeletedBoxItem item,
        int date);

    IUpdates ToEditUpdates(OutboxMessageEditCompletedEvent aggregateEvent,
        long selfUserId);

    IUpdates ToEditUpdates(InboxMessageEditCompletedEvent aggregateEvent);

    IUpdates ToInboxForwardMessageUpdates(ReceiveInboxMessageCompletedEvent aggregateEvent);

    IUpdates ToInviteToChannelUpdates(SendOutboxMessageCompletedEvent aggregateEvent,
        StartInviteToChannelEvent startInviteToChannelEvent,
        //IChat channel,
        IChannelReadModel channelReadModel,
        bool createUpdatesForSelf);

    IUpdates ToInviteToChannelUpdates(IChat channel,
        IUserReadModel senderUserReadModel,
        int date);

    IUpdates ToReadHistoryUpdates(ReadHistoryCompletedEvent eventData);
    IUpdates ToReadHistoryUpdates(UpdateOutboxMaxIdCompletedSagaEvent eventData);
    IUpdates ToSelfOtherDeviceUpdates(SendOutboxMessageCompletedEvent aggregateEvent);

    IUpdates ToSelfUpdatePinnedMessageUpdates(UpdatePinnedMessageCompletedEvent aggregateEvent);
    IUpdates ToSelfUpdates(SendOutboxMessageCompletedEvent aggregateEvent);
    IUpdates ToUpdatePinnedMessageServiceUpdates(SendOutboxMessageCompletedEvent aggregateEvent);

    IUpdates ToUpdatePinnedMessageUpdates(UpdatePinnedMessageCompletedEvent aggregateEvent);

    IUpdates ToUpdatePinnedMessageUpdates(SendOutboxMessageCompletedEvent aggregateEvent);

    IUpdates ToUpdatePinnedMessageUpdates(ReceiveInboxMessageCompletedEvent aggregateEvent);

    IUpdates ToUpdates(ReceiveInboxMessageCompletedEvent aggregateEvent);

    IUpdates ToDraftsUpdates(IReadOnlyCollection<IDraftReadModel> draftReadModels);

    IUpdates ToChannelUpdates(long selfUserId, IChannelReadModel channelReadModel, IPhotoReadModel? photoReadModel);
}
