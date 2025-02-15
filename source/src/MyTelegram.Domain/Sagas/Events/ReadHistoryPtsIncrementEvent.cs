﻿namespace MyTelegram.Domain.Sagas.Events;

public class ReadHistoryPtsIncrementEvent(
    RequestInfo requestInfo,
    long peerId,
    int pts,
    int readCount,
    int unreadCount,
    PtsChangeReason reason)
    : RequestAggregateEvent2<ReadHistorySaga, ReadHistorySagaId>(requestInfo), IHasCorrelationId
{
    public long PeerId { get; } = peerId;
    public int Pts { get; } = pts;
    public int ReadCount { get; } = readCount;
    public int UnreadCount { get; } = unreadCount;
    public PtsChangeReason Reason { get; } = reason;
}
