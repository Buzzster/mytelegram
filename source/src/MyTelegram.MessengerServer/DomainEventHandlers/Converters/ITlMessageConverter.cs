﻿namespace MyTelegram.MessengerServer.DomainEventHandlers.Converters;

public interface ITlMessageConverter
{
    IMessage ToMessage(MessageItem item,
        long selfUserId = 0, long? linkedChannelId = null, int pts = 0);

    IMessage ToMessage(InboxMessageEditCompletedEvent aggregateEvent);

    IMessage ToMessage(OutboxMessageEditCompletedEvent aggregateEvent,
        long selfUserId);

    IMessageFwdHeader? ToMessageFwdHeader(MessageFwdHeader? messageFwdHeader);
    IMessageReplyHeader? ToMessageReplyHeader(int? replyToMessageId);

    IList<IMessage> ToMessages(IReadOnlyCollection<IMessageReadModel> readModels,
        long selfUserId);
    IMessage ToDiscussionMessage(IMessageReadModel messageReadModel,int maxId,int readMaxId,int readInboxMaxId,int readOutboxMaxId,long selfUserId);
}
