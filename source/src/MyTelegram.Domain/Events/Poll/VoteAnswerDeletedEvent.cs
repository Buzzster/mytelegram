﻿namespace MyTelegram.Domain.Aggregates.Poll;

public class VoteAnswerDeletedEvent(
    long pollId,
    long voterPeerId) : AggregateEvent<PollAggregate, PollId>
{
    public long PollId { get; } = pollId;
    public long VoterPeerId { get; } = voterPeerId;
}
