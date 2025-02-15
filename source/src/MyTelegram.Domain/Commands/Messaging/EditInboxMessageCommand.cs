﻿namespace MyTelegram.Domain.Commands.Messaging;

public class EditInboxMessageCommand(
    MessageId aggregateId,
    RequestInfo requestInfo,
    int messageId,
    string newMessage,
    int editDate,
    byte[]? entities,
    byte[]? media)
    : RequestCommand2<MessageAggregate, MessageId, IExecutionResult>(aggregateId, requestInfo)
{
    public int MessageId { get; } = messageId;
    public string NewMessage { get; } = newMessage;
    public byte[]? Entities { get; } = entities;
    public byte[]? Media { get; } = media;
    public int EditDate { get; } = editDate;
}